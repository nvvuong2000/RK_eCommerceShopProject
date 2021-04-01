using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared
{
    public class ProductVM
    {
        public int providerID { get; set; }
        public int producerID { get; set; }
        public int categoryID { get; set; }
        public int productID { get; set; }
        public string productName { get; set; }
        public int stock { get; set; }
        public decimal unitPrice { get; set; }
        public string description { get; set; }
        public bool isNew { get; set; }

       
    }
}
