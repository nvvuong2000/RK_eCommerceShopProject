using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
    public interface IOrder
    {
        public Task<List<Order>> myOrderList();
        public Task<List<OrderDetails>> myOrderListbyId(int id);
    }
}
