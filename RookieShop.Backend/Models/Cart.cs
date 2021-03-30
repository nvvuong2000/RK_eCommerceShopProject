
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Cart
    {
        public int cartID { get; set; }
        public string userID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        

    }
}
