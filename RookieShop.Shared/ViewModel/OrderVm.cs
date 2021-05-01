using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
   public  class OrderVm
    {
        public int Id { get; set; }
        public List<int> ProductID { get; set; }
        public List<string> ProductName { get; set; }
        public List<int> Quantity { get; set; }
        public List<decimal> UnitPrice { get; set; }
        public IEnumerable<string> ImageDefault { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserTel { get; set; }
    }
}
