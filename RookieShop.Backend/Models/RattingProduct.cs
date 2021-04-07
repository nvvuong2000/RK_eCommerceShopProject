

using  RookieShop.Backend.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace  RookieShop.Backend.Models
{
    public class RattingProduct
    {
        public int Id { get; set; }
        public string userID { get; set; }
        public int productID { get; set; }
        public int numberRating { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

    }
}
