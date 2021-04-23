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
        public int stock { get; set; }
        public bool status { get; set; }
        public bool isNew { get; set; }
        public string imgDefault { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int providerID{ get; set; }
        public int count { get; set; }
        //public ICollection<ProductImages> ProductImages { get; set; }
    }
}
