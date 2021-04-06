using  RookieShop.Backend.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace RookieShop.Backend.Models
{
    public class User: IdentityUser
    {
  
        public string customerName { get; set; }

        public string address { get; set; }

        public string avatar { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<RattingProduct> RattingProduct { get; set; }
        public Cart Cart { get; set; }
    }
}
