using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared
{
    public class ProductRequest
    {
        public int ProviderId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public bool IsNew { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public DateTime DateUpdated { get; set; } 
        public List<IFormFile> FormFiles { get; set; }


    }
}
