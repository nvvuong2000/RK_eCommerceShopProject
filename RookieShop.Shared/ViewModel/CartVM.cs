using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
   public  class CartVM
    {
        public int Id { get; set; }
        public string productName { get; set; }
     
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public string description { get; set; }
       public string pathName { get; set; }
    }
}
