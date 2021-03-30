using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
