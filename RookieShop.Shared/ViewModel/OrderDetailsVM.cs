using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
   public  class OrderDetailsVM
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public int status { get; set; }
    }
}
