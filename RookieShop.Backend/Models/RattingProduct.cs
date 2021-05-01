

using  RookieShop.Backend.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace  RookieShop.Backend.Models
{
    public class RattingProduct
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int NumberRating { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

    }
}
