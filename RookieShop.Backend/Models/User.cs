using  RookieShop.Backend.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace RookieShop.Backend.Models
{
    public class User: IdentityUser
    { 
        public string CustomerName { get; set; }
     
        public string Address { get; set; }
        
        public string Avatar { get; set; }
        
        public ICollection<Order> Orders { get; set; }
        
        public ICollection<RattingProduct> RattingProduct { get; set; }
      
    }
}
