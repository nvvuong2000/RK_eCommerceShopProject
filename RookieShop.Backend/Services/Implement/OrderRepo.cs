using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{
    public class OrderRepo : IOrder
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDF _repoUser;

        public OrderRepo(ApplicationDbContext context, IUserDF repoUser)
        {
            _context = context;
            _repoUser = repoUser;
        }
        public async Task<List<Order>> myOrderList()
        {
            var listOrder = await _context.Order.Include(o => o.OrderDetails).Include(o => o.OrderDetails).Where(x => x.userId == _repoUser.getUserID()).ToListAsync();
            return listOrder;
        }

        public async Task<List<OrderDetails>> myOrderListbyId(int id)
        {
            var result = await _context.OrderDetails.Where(od => od.Id == id).ToListAsync();
            return result;
        }
    }
}
