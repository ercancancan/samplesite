 using ES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ES.Controllers
{
   public class BaseController : Controller
    {
        public Customer CurrentCustomer;
      
        public SmdbDataContext Db = new SmdbDataContext();
       // bu ksım ne işe yarıyor anladın mı ? 
       // sayfa şlk yuklendıgınde yuklenen ok

       // bu metod, açılan her sayfadan önce çalışıyor gerekli bazı ayarlamalkr yapıyor
       // mesela kategorileri getiriyor, ya da oturum açan kullancının bilgisini okuyor vs.
       // doğru anlamış mıyım evet hocam. ok lakin yanlış yerde. bunun gibi iki tane var. 
       // Biri ActionExecuted, diğeri Action Executing

       // asıl her sayfadan öçnce çalışan bu
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.categoryList = Db.Categories.OrderBy(d => d.OrderNumber).ToList();

            var customer = (Session["LoginKey"] as Customer);

            if (filterContext.ActionDescriptor.ActionName != "Login")
                if (customer == null)
                {
                    filterContext.Result = RedirectToAction("Login", "My");
                    return;
                }
            CurrentCustomer = customer;
            // bu en sona bırakılırsa iyi olur. Çünkü yukarıda birşeyler ters giderse, boşu boşuna bunu yapmamış olur
            base.OnActionExecuting(filterContext); // bu kısım sayfanın normalde yapacağı şeyler,
        }

       // bu her sayfadan "sonra" çalışıyor. Ya adam yanlış anlatmış, yada yazarken harf hatası yapmöışsın. 
       //buyuk ıhtımal ben hatayapmısımdır hocam cunku ben farkı bılıyordum sımdı sızın solemenızle fark ettım
       //Dıger hocanın kı calsııyordu
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public static IQueryable<Models.Product> AddFilter(DefaultFilter filter, IQueryable<Models.Product> list)
        {
             if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.SearchString))
                {
                    list = list.Where(d => d.Title.Contains(filter.SearchString) || d.Model.Contains(filter.SearchString) || d.Description.Contains(filter.SearchString));
                }
                if (filter.SortDir == SortDir.Asc)
                {
                    if (filter.Sort == ProductColumnEnum.Title)
                        list = list.OrderBy(d => d.Title);
                    if (filter.Sort == ProductColumnEnum.Price)
                        list = list.OrderBy(d => d.Price);
                    if (filter.Sort == ProductColumnEnum.Model)
                        list = list.OrderBy(d => d.Model);
                }
                else
                {
                    if (filter.Sort == ProductColumnEnum.Title)
                        list = list.OrderByDescending(d => d.Title);
                    if (filter.Sort == ProductColumnEnum.Price)
                        list = list.OrderByDescending(d => d.Price);
                    if (filter.Sort == ProductColumnEnum.Model)
                        list = list.OrderByDescending(d => d.Model);
                }
            }
            return list;
        }
       
    }
}
