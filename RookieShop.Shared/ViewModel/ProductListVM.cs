using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
    public class ProductListVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public bool Status { get; set; }
        public bool IsNew { get; set; }
        public string ImgDefault { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProviderId{ get; set; }

    }
}
