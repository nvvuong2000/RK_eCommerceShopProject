using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Containts
{
    public static class APICartEndPoint
    {
        public const string GetList = "Cart";

        public const string InsertToCart = "Cart/add/";

        public const string DeleteFromCart = "Cart/remove/";

        public const string Total = "Cart/total";

        public const string Checkout = "Cart/checkout";
    }
}
