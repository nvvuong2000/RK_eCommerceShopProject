
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookieShop.Backend.Models
{
    public class Cart
    {   
        public string UserId { get; set; }   
        
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }
        

    }
}
