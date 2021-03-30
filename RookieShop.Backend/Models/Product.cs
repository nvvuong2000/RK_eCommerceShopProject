
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class Product
    {
        public int productID { get; set; }
        public int providerID { get; set; }
        public int producerID { get; set; }
        public int categoryID { get; set; }

        public string productName { get; set; }
        public int stock { get; set; }
        public decimal unitPrice { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public int viewCount { get; set; }
        public int buyCount { get; set; }
        public bool isNew { get; set; }
    
        public Category Category { get; set; }
        public ICollection<ProductImages> ProductImages {get;set;}
        public IList<ProviderProduct> ProviderProducts { get; set; }
        public IList<ProducerProduct> ProducerProducts { get; set; }

    }
}
