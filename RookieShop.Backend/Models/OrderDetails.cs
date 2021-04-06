using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class OrderDetails

    {
        public int orderdetailsID { get; set; }
        public int orderID { get; set; }
        public int productID { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
