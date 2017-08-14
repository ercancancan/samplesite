using ES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ES.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home1/
    
        
        public ActionResult Index()
        {
            ViewBag.Title = "Anasayfa";
            return View(new HomeVm
            { 
           
            ProductList = Db.Products.ToList()
            });
        }

       
    }
}
