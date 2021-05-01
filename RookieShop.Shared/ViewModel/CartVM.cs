using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
   public  class CartVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
     
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
       public string PathName { get; set; }
    }
}
