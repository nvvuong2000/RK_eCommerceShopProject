using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
   public  class ProductImagesVM
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string pathName { get; set; }
        public string captionImage { get; set; }
        public bool isDefault { get; set; }
    }
}
