using System;
using System.Collections.Generic;

using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ES.Models
{
   public class DefaultFilter
    {
       public string SearchString { get; set; }
        public ProductColumnEnum Sort { get; set; }
        public SortDir SortDir { get; set; }
    }
    public static class UrlCreater
    {
        public static MvcHtmlString Create(ProductColumnEnum eColumnEnum,NameValueCollection collection)
        {
            var dir = "asc";
            var tag = new TagBuilder("a");
          
            var value = collection.Get("SortDir");
            if(!string.IsNullOrEmpty(value))
            {
                if(value == "asc")
                {
                    dir = "desc";
                }
            }
            tag.Attributes.Add("href", "/Product/Index" + "?Sort" + eColumnEnum + "&SortDir" + dir);
           switch(eColumnEnum )
           {
               case ProductColumnEnum.Price:
               tag.SetInnerText("Fiyata Göre Sırala");
           break;

               case ProductColumnEnum.Model:
               tag.SetInnerText("Modele Göre Sırala");
           break;
               case ProductColumnEnum.Title:
               tag.SetInnerText("Baslıga Göre Sırala");
           break;
           }
          
          
            return new MvcHtmlString(tag.ToString());
        }
    }
}
