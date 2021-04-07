
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int providerId { get; set; }
       
        public int categoryId { get; set; }

        public string productName { get; set; }
        public int stock { get; set; }
        public decimal unitPrice { get; set; }
        public string description { get; set; }
        
   
        public bool isNew { get; set; }
        public bool status { get; set; }
        public double rating { get; set; }
    
        public Category Category { get; set; }
        public ICollection<ProductImages> ProductImages {get;set;}
        public ICollection<ProviderProduct> ProviderProducts { get; set; }
        public ICollection<RattingProduct> RattingProduct { get; set; }

    }
}
