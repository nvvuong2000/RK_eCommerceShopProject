using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
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
        public async Task<List<OrderVm>> myOrderList()
        {
            var listOrder = await _context.Order.Include(o => o.OrderDetails).Include(o=>o.OrderDetails).Where(x => x.userId == _repoUser.getUserID()).Select(x=>new OrderVm {
                Id = x.Id,
                productName = x.OrderDetails.Select(o=>o.productName).ToList(),
                quantity = x.OrderDetails.Select(o => o.quantity).ToList(),
                total = x.Total,
                status = x.status,
                unitPrice = x.OrderDetails.Select(o=>o.unitPrice).ToList(),
                date = x.dateOrdered,

            }).ToListAsync();
            return listOrder;
        }

        public async Task<OrderVm> getorDetailsbyOrderId(int id)
        {
            var listOrder = await _context.Order.Include(o => o.OrderDetails).Include(o => o.OrderDetails).Where(x => x.userId == _repoUser.getUserID() && x.Id == id).Select(x => new OrderVm
            {
                Id = x.Id,
                productName = x.OrderDetails.Select(o => o.productName).ToList(),
                quantity = x.OrderDetails.Select(o => o.quantity).ToList(),
                total = x.Total,
                status = x.status,
                unitPrice = x.OrderDetails.Select(o => o.unitPrice).ToList(),
                date = x.dateOrdered,

            }) .FirstOrDefaultAsync();
            return listOrder;
        }
        public async Task<Order> myOrderListbyId(int id)
        {
            var result = _context.Order.Where(od => od.Id == id).FirstOrDefault();
            return result;
        }

        public bool updateSttOrdrerAd(StatusOrderRequest statusRequest )
        {
            var order = _context.Order.Where(od => od.Id == statusRequest.orderId).FirstOrDefault();
            if (order == null)
            {
                return false;
            }
            order.status = statusRequest.statusId;

            _context.Order.Update(order);
            _context.SaveChanges();
            return true;
        }

        public bool updateSttOrdrerCs(int Id)
        {
            var order = _context.Order.Where(od => od.Id == Id).FirstOrDefault();
            if (order == null)
            {
                return false;
            }
            order.status = 2;
            _context.Order.Update(order);
            _context.SaveChanges();
            return true;
        }

  
    }
}
