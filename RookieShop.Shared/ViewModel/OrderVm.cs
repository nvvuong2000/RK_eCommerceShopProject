using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
   public  class OrderVm
    {
        public int Id { get; set; }
        public List<int> productID { get; set; }
        public List<string> productName { get; set; }
        public List<int> quantity { get; set; }
        public List<decimal> unitPrice { get; set; }
        public IEnumerable<string> imageDefault { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public int status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserTel { get; set; }
    }
}
