using ES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ES.Controllers
{
    public class MyController : BaseController
    {
       
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Giriş Yap";
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            if(ModelState.IsValid)
            {
                var cus = Db.Customers.SingleOrDefault(d => d.EmailAdress.Equals(customer.EmailAdress) && 
                    d.Password.Equals(customer.Password));
                if (cus != null)
                {
                    Session["LoginKey"] = cus;
                    return RedirectToAction("Index", "Home");
                }

            }
            ViewBag.Title = "Grirş Yap";
            return View(customer);

        }
        public ActionResult Index()
        {
            ViewBag.Title = "Sepetim";
            ViewBag.BasketProducts = Db.CustomerOfBaskets.Where(d => d.CustomerId == CurrentCustomer.Id).Select(d => d.Product).ToList();

            ViewBag.Sales = Db.Sales.Where(d => d.CustomerId == CurrentCustomer.Id).ToList();
            return View();
        }
        public ActionResult AddBasket(int? id)
        {
            if (id.HasValue)
            {
                //var customer = (Session["LoginKey"] as Customer);
                if (!Db.CustomerOfBaskets.Any(d => d.ProductId == id && d.CustomerId ==CurrentCustomer.Id))
                {
                     var basketItem = new CustomerOfBasket
                {
                    CustomerId = CurrentCustomer.Id,
                    ProductId = id.Value
                };
                Db.CustomerOfBaskets.InsertOnSubmit(basketItem);
                Db.SubmitChanges();
                }
               
              
            }
            Session["LoginKey"] = Db.Customers.Single(d => d.Id == CurrentCustomer.Id);
            return RedirectToAction("Index");


        }
        public ActionResult RemoveBasket(int? id)
        {
            if (id.HasValue)
            {
                //var customer = (Session["LoginKey"] as Customer);
                var basketItem = Db.CustomerOfBaskets.SingleOrDefault(d =>d.ProductId == id && d.CustomerId == CurrentCustomer.Id);
                if (basketItem != null)
                {
                    Db.CustomerOfBaskets.DeleteOnSubmit(basketItem);
                    Db.SubmitChanges(); 
                }
              

            }
            Session["LoginKey"] = Db.Customers.Single(d => d.Id == CurrentCustomer.Id);
            return RedirectToAction("Index");


        }
    }
}
