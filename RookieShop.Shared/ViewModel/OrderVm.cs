using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
   public  class OrderVm
    {
        public int Id { get; set; } 
        public List<string> productName { get; set; }
        public List<int> quantity { get; set; }
        public List<decimal> unitPrice { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public int status { get; set; }
    }
}
