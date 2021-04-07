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
    public class CartRepo : ICart
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDF _repoUser;

        public CartRepo(ApplicationDbContext context, IUserDF repoUser)
        {
            _context = context;
            _repoUser = repoUser;
        }
        public async Task<int> FindID(int id)
        {
            
            var listItem = await _context.Carts.Where(x => x.userId == _repoUser.getUserID()).ToListAsync();

            for (int i = 0; i < listItem.Count; i++)
            {

                if (listItem[i].productId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public async Task<bool> AddProductIntoCart(int id)
        {
            var listItem = await _context.Carts.Where(x => x.userId == _repoUser.getUserID()).ToListAsync();
            var result = _context.Products.FirstOrDefault(x => x.Id == id);
            if (result.stock <= 0)
            {
                throw new Exception("Hết hàng");

            }
            else if (result == null)
            {
                throw new Exception("Không tìm thấy");
            }
           
            else
            {
                var index = await FindID(id);
                if (index != -1)
                {
                    listItem[index].quantity = listItem[index].quantity + 1;
                    _context.Carts.Update(listItem[index]);
                }
                else
                {

                    var newItem = new Cart { productId = id, quantity = 1, unitPrice = result.unitPrice, userId = _repoUser.getUserID() };
                  
                    _context.Carts.Add(newItem);
                    await _context.SaveChangesAsync();


                }
                    result.stock = result.stock - 1;
                    _context.Products.Update(result);
                    await _context.SaveChangesAsync();
                
            }
            return true;
        }

        public async Task<List<Cart>> myCart(string id)
        {
            var list = await _context.Carts.Where(c => c.userId.Equals(id)).ToListAsync();
            if (list.Count == 0)
            {
                return null;
            }
            return list;
        }

        public async Task<bool> RemoveItem(int id)
        {
            var listItem = await _context.Carts.Where(x => x.userId == _repoUser.getUserID()).ToListAsync();
            var result = _context.Products.FirstOrDefault(x => x.Id == id);

            int index = await FindID(id);
            if (index == -1)
            {
                return false ;

            }
            _context.Carts.Remove(listItem[index]);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
