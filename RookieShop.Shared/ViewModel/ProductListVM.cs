using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
    public class ProductListVM
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal unitPrice { get; set; }
        public bool isNew { get; set; }
        public string imgDefault { get; set; }

        //public ICollection<ProductImages> ProductImages { get; set; }
    }
}
