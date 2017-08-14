using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ES.Models
{
    public class UserCardInfo
    {
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string CardHasName { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }
        public int Id { get; set; }
    }
}