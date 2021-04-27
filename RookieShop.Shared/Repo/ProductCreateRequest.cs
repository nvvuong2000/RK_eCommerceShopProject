using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared
{
    public class ProductCreateRequest
    {
        public int providerID { get; set; }
        public int categoryID { get; set; }
        public int productID { get; set; }
        public string productName { get; set; }
        public int stock { get; set; }
        public decimal unitPrice { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public bool isNew { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public DateTime DateUpdated { get; set; } 
        public List<IFormFile> FormFiles { get; set; }


    }
}
