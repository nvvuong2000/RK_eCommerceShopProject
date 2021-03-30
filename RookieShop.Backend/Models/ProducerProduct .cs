

using  RookieShop.Backend.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace  RookieShop.Backend.Models
{
    public class ProducerProduct
    {
        public int producerID { get; set; }
        public int productID { get; set; }
        public Producer Producer { get; set; }
        public Product Product { get; set; }

    }
}
