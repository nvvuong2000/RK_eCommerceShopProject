using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public int providerId { get; set; }

        public int categoryId { get; set; }

        public string productName { get; set; }
        public int stock { get; set; }
        public decimal unitPrice { get; set; }
        public string description { get; set; }
        public string categoryName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool isNew { get; set; }
        public bool status { get; set; }
        public double rating { get; set; }

        public ICollection<ProductImagesVM> ProductImages { get; set; }

    }
}
