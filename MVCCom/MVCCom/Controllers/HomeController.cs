using MVCCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCom.Controllers
{
    public class HomeController : Controller
    {
        MVCUrunlerDB db = new MVCUrunlerDB();

            public HomeController()
         {
                     using(var db= new MVCUrunlerDB())
                {
                    var kategori = db.Kategoriler.ToList();
                    ViewBag.Kategoriler = kategori;
                }
                
          }

        public ActionResult Index()
        {
            using(var db = new MVCUrunlerDB())
            {
                var urunler = db.Urunler.ToList();
                return View(urunler);
            }
            
        }
        public ActionResult Kategori(int KategoriId)
        {
            using(var db = new MVCUrunlerDB())
            {
               var kat =db.Urunler.Where(k => k.KategoriId == KategoriId).ToList();
               return View(kat);
            }
            
        }
        public ActionResult Detay(int urunId)
        {

            using (var db = new MVCUrunlerDB())
            {
                var det = db.Urunler.Where(d => d.UrunId == urunId).ToList();
                return View(det);
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}
