
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Backend.Models
{
    public class ProviderProduct
    {
        public int providerID { get; set; }
        public int productID { get; set; }
        public Product Product { get; set; }
        public Provider Provider { get; set; }
    }
}
