using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Repo
{
    public class StatusOrderRequest
    {
        public int orderId { get; set; }
        public int statusId { get; set; }
    }
}
