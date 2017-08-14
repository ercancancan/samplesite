using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ES.Models
{
    public  class CustomerValidation
    {
     
        [Required(ErrorMessage= "Boş bırakmayınız")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Boş bırakmayınız")]
        public string Password { get; set; }
    }
    [MetadataType(typeof(CustomerValidation))]
    public partial class Customer
    {
        public double GetTotalBasketValue()
        {
            return CustomerOfBaskets.Sum(d => d.Product.Price);
        }
    }
}