using RookieShop.Backend.Models;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
    public interface IOrder
    {
        public Task<List<OrderVm>> myOrderList();
        public Task<OrderVm> getorDetailsbyOrderId(int id);
        public bool updateSttOrdrerCs(int id);
        public bool updateSttOrdrerAd(StatusOrderRequest statusRequest);
    }
}
