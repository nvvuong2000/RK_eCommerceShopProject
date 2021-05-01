using RookieShop.Shared.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
    public interface ICart
    {
        public Task<List<CartVM>> myCart();
        
        public Task<bool> AddProductIntoCart(int id);

        public Task<bool> addorupdateMulProduct(int Id, int quan, bool isUpdate);

        public Task<bool> RemoveItem(int id);
        
        public Task<decimal> TotalBill();
        
        public Task<int> FindProductByIdInCart(int id);
       
        public Task<bool> Checkout();




    }
}
