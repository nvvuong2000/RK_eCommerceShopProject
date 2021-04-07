using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class OrderDetails

    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
