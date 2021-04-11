using RookieShop.Backend.Models;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
    public interface ICart
    {
        public Task<List<CartVM>> myCart();
        public Task<bool> AddProductIntoCart(int id);
        public Task<bool> RemoveItem(int id);
        public Task<decimal> TotalBill();
        public Task<int> FindId(int id);
        public Task<bool> Checkout();




    }
}
