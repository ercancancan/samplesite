using ePayment;
using ES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ES.Controllers
{
    public class ProductController : BaseController
    {
        //
        // GET: /Product/
        //Urun listesi , Kategoriye gore  sıralama
        public ActionResult Index(string id,DefaultFilter filter)
        {
            ViewBag.Title = "Ürün Listesi";
            var list = Db.Products.AsQueryable();
            if(!string.IsNullOrEmpty(id))
            {
                list = list.Where(d => d.Category.SeoText.Equals(id));
                ViewBag.CategoryName = Db.Categories.Single(d => d.SeoText.Equals(id)).Text;
            }
            list = AddFilter(filter, list);
            return View(list.ToList());
        }
        //private IQueryable<Models.Product> AddFilter(DefaultFilter filter, IQueryable<Models.Product> list)
        //{
        //    throw new NotImplementedException();
        //}
       
        public    ActionResult Detail(string id)
        {
            
            var product = Db.Products.SingleOrDefault(d => d.Seo.Equals(id));
            if (product == null)
                throw new Exception("Urun bulunamadı");
            ViewBag.Title = product.Title;
            return View(product);
        }
        public ActionResult Sale(int id)
        {
            var product = Db.Products.SingleOrDefault(d => d.Id.Equals(id));
            if (product == null)
                return RedirectToAction("Index");
            return View(product);

        }

        [HttpPost]
        public ActionResult Sale(UserCardInfo cardInfo)
        {
            var product = Db.Products.SingleOrDefault(d => d.Id == cardInfo.Id);
            if (product == null)
            return RedirectToAction("Index");
            ViewBag.Result = "";
            var payment = new cc5payment
            {
                host = "host",
                name = "",
                password = "",
                clientid = "",
                orderresult = 0,
                cardnumber = cardInfo.CardNumber,
                expmonth = cardInfo.ExpMonth.ToString(),
                expyear = cardInfo.ExpYear.ToString(),
                cv2 = cardInfo.SecurityNumber,
                currency = "949",
                chargetype = "Auth",
                ip = Request.ServerVariables["REMOTE_ADDR"],
                subtotal = product.Price.ToString(),
                taksit = "1"
            };
            string bankaSonuc = payment.processorder(); //Methot Çagır
            string bankaHata = payment.errmsg; //Dönen hatamesajı
            string bakaOid = payment.oid;//Dönen order id
            string bankaAppr = payment.appr; //Dönen işlem sonucu
            string bankaProv = payment.code; //Dönen provizyon numarası

            if (bankaSonuc == "1")
            {
                if (bankaAppr == "Approved") //Ödemeişlemi tamam
                {
                    ViewBag.Result = "BanKa ödemeyi kabul etti.Ödeme işlemi başarıile tamamlandı";

                }
                else if (bankaAppr == "Declined") //Ödeme işlemi reddedildi
                {
                    ViewBag.Result = "Banka ödemeyi reddetti";
                }
                else
                {
                    ViewBag.Result = "Banka ile işlem kurulmadı";
                }
            }
            var sale = new Sale
            {
                CargoPrice = 20,
                CustomerId = CurrentCustomer.Id,
                ProductId = cardInfo.Id,
                RecordDate= DateTime.Now,
                SaleState = (short)SaleState.PendingCheck
            };
            Db.Sales.InsertOnSubmit(sale);
            Db.SubmitChanges();
               return RedirectToAction("Index");
         
        }

    }
  
}
