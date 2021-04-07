
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Backend.Models
{
    public class ProviderProduct
    {
        public int providerId { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
        public Provider Provider { get; set; }
    }
}
