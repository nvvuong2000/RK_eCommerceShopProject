using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class ProductImages
    {
        public int ID { get; set; }
        
        public int ProductID { get; set; }
        
        public string PathName { get; set; }
        
        public string CaptionImage { get; set; }
        
        public bool IsDefault{ get; set; }
        
        public Product Product { get; set; }


    }
}
