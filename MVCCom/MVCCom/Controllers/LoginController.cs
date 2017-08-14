using MVCCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCom.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Index(Kullanicilar k)
        {
            if (ModelState.IsValid)
            {

                using(MVCUrunlerDB db = new MVCUrunlerDB())
                { 
                    var v = db.Kullanicilar.Where(a => a.KullaniciAdi.Equals(k.KullaniciAdi) && a.Sifre.Equals(k.Sifre)).FirstOrDefault();
            if (v != null)
	         {
                 Session["KullaniciId"] = v.Id.ToString();
                 Session["KullaniciAdi"] = v.KullaniciAdi.ToString();
                 return RedirectToAction("Urunler");


            }
          }
        }
            return View(k);
     }
      //  [HttpPost]
      //public ActionResult Index(Kullanicilar k1)
      //  {
      //      MVCUrunlerDB db = new MVCUrunlerDB();
      //      if (k1.KullaniciAdi.Equals(db.Kullanicilar.Select(s => s.KullaniciAdi)) && k1.Sifre.Equals(db.Kullanicilar.Select(s => s.Sifre)))
      //      {
      //          Session["user"] = k1.KullaniciAdi;
      //          return RedirectToAction("Urunler");
      //      }
      //      else
      //      {
      //          ViewBag.Error = "da";
      //          return View("Index");
      //      }
      //  }


        //[HttpPost]
        //public ActionResult Index(string kullaniciAdi,string kullaniciSifre)
        //{
        //    using(var db = new MVCUrunlerDB())
        //    {
                
        //        if (ModelState.IsValid)
        //        {
        //            var giris = db.Kullanicilar.Where(g => g.KullaniciAdi == kullaniciAdi && g.Sifre == kullaniciSifre).ToList();
        //            return RedirectToAction("Urunler");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index");
        //        }
                
        //    }
         
        //}

        public ActionResult Urunler()
        {
            using(MVCUrunlerDB db = new MVCUrunlerDB())
            {
                if (Session["KullaniciAdi"] != null)
                {
                    //return View();
                    var urun = db.Urunler.ToList();

                    return View(urun);

                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            
        }
        public ActionResult Detail(int id)
        {
            using(MVCUrunlerDB db = new MVCUrunlerDB())
            {
                var edit = db.Urunler.SingleOrDefault(e => e.UrunId == id);
                return View(edit);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            MVCUrunlerDB db = new MVCUrunlerDB();
            var edit = db.Urunler.SingleOrDefault(e => e.UrunId == id);
            if (edit != null)
            {
               
            }
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(Urunler user)
        {
            MVCUrunlerDB db = new MVCUrunlerDB();
            if (ModelState.IsValid)
            {
                var edit = db.Urunler.SingleOrDefault(e => e.UrunId == user.UrunId);
                edit.UrunId = user.UrunId;
                edit.Adi = user.Adi;
                edit.Fiyati = user.Fiyati;
                edit.KucukGorsel = user.KucukGorsel;
                edit.KategoriId = user.KategoriId;
                db.SaveChanges();
                TempData["Message"] = "Kullanıcı duzenlendı";
                return RedirectToAction("Urunler");
            }
            return View(user);

        }
        public ActionResult Delete(int id)
        {
            MVCUrunlerDB db = new MVCUrunlerDB();

            var del = db.Urunler.SingleOrDefault(d => d.UrunId == id);
            db.Urunler.Remove(del);
            db.SaveChanges();
            TempData["Message"] = "Urun silindi";
            return RedirectToAction("Urunler");
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Urunler yeniUrun)
        {
            MVCUrunlerDB db = new MVCUrunlerDB();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Guid.NewGuid().ToString();
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string tamyolyeri = "~/Images/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(tamyolyeri));
                    yeniUrun.KucukGorsel = dosyaadi + uzanti;

                }
                else
                {
                    yeniUrun.KucukGorsel = "~/Images/a.jpg";
                }
                db.Urunler.Add(yeniUrun);
                db.SaveChanges();
                return RedirectToAction("Urunler");
            }
            else
            {
                return View(yeniUrun);
            }
            
         
           
        }

    }
}
