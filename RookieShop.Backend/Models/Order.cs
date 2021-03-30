
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public string userID { get; set; }
        public int status { get; set; }
        public DateTime dateOrdered { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
