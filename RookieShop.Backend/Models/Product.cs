
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

        public int ProviderId { get; set; }
       
        public int CategoryId { get; set; }

        public string ProductName { get; set; }
        
        public int Stock { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public string Description { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public DateTime DateUpated { get; set; }
        
        public bool IsNew { get; set; }
        
        public bool Status { get; set; }
        
        public double Rating { get; set; }
    
        public Category Category { get; set; }
       
        public ICollection<ProductImages> ProductImages {get;set;}
        
        public ICollection<ProviderProduct> ProviderProducts { get; set; }
        
        public ICollection<RattingProduct> RattingProduct { get; set; }

      
    }
}
