using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{
    public class CartRepo : ICart
    {
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _config;

        private readonly IUserDF _repoUser;

        public CartRepo(ApplicationDbContext context, IUserDF repoUser, IConfiguration config )
        {
            _context = context;

            _repoUser = repoUser;

            _config = config;
        }
        
  
        public async Task<bool> AddProductIntoCart(int id)
        {
            // Check Current User

            var Userid = _repoUser.getUserID();

            // Get list product in cart's customer 

            var listItem = await _context.Carts.Where(x => x.UserId.Equals(_repoUser.getUserID())).ToListAsync();

            // Search product by product id in product list  then get some property of product

            var result = _context.Products.FirstOrDefault(x => x.Id == id);

            // Check whether products are in the shopping cart?

            var index = await FindProductByIdInCart(id);

            // if produtc not exits in product list false

            if (result == null)
            {
                return false;
            }
            else
            {
                // if stock of product less 0 then return false

                if (result.Stock <= 0)
                {

                    return false;

                }
                else
                {
                    // In case: product is exists in cart

                    if (index != -1)
                    {

                        // Increase quantity of product by 1

                        listItem[index].Quantity = listItem[index].Quantity + 1;

                        //  and update this product in cart 

                        _context.Carts.Update(listItem[index]);
                    }

                    // In case: product is not exists in cart

                    else
                    {

                        // create new item in cart

                        var newItem = new Cart { ProductId = id, Quantity = 1, UnitPrice = result.UnitPrice, UserId = Userid };

                        // add item  in cart

                        _context.Carts.Add(newItem);
                    }
                }
            }
            // save

            await _context.SaveChangesAsync();

            return true;

        }


        // This method get list cart item;

        public async Task<List<CartVM>> myCart()
        {
            var list = await _context.Carts.Include(c => c.Product).Include(c=>c.Product.ProductImages).Where(c => c.UserId.Equals(_repoUser.getUserID())).Select(x => new CartVM
            {
                Id = x.ProductId,

                ProductName = x.Product.ProductName,

                UnitPrice = x.Product.UnitPrice,

                Quantity = x.Quantity,

                PathName = x.Product.ProductImages.Where(x=>x.IsDefault==true).Select(x => _config["Host"]+ x.PathName).FirstOrDefault(),

            }).ToListAsync();

            return list;
        }

        // This method remove item in customer's cart ;

        public async Task<bool> RemoveItem(int id)
        {
            var listItem = await _context.Carts.Where(x => x.UserId == _repoUser.getUserID()).ToListAsync();

            var result = _context.Products.FirstOrDefault(x => x.Id == id);

            int index = await FindProductByIdInCart(id);

            if (index == -1)
            {
                return false ;

            }
            _context.Carts.Remove(listItem[index]);

            await _context.SaveChangesAsync();

            return true;
        }

        // This method return total money in customer's cart
        public async  Task<decimal> TotalBill()
        {
            decimal total = 0;

            var listItem = await _context.Carts.Where(x => x.UserId == _repoUser.getUserID()).ToListAsync();

            for (int i = 0; i < listItem.Count; i++)
            {

                total += listItem[i].UnitPrice * listItem[i].Quantity;
            }

            return total;
        }

        // This method return index of product in customer'cart; if exits return index else return -1;

        public async Task<int> FindProductByIdInCart(int id)
        {

            var listItem = await _context.Carts.Where(x => x.UserId == _repoUser.getUserID()).ToListAsync();

            for (int i = 0; i < listItem.Count; i++)
            {

                if (listItem[i].ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        // This method create new order for customer and remove item in cart if checkout  finishe
        public async Task<bool> Checkout()
        {
            // get list item in cart's customer

            var listItem = await _context.Carts.Where(x => x.UserId == _repoUser.getUserID()).ToListAsync();

            // create new order 

            var order = new Order()
            {
                UserId = _repoUser.getUserID(),

                DateOrdered = DateTime.Now,

                Status = 0,

                Total = await TotalBill(),
            };

            // add order

            _context.Order.Add(order);

            // save order

            await _context.SaveChangesAsync();


            // create order details  of order above

            for (int i = 0; i < listItem.Count; i++)
            {
                var result = _context.Products.FirstOrDefault(x => x.Id == listItem[i].ProductId);

                Random random = new Random();

                int randomNumber = random.Next(0, 1000);

                var orderItem = new OrderDetails()
                {

                    OrderId = order.Id,

                    ProductId = listItem[i].ProductId,

                    Quantity = listItem[i].Quantity,

                    UnitPrice = listItem[i].UnitPrice,

                    ProductName = result.ProductName,
                };
             
                // and remove item in customer's cart

                _context.Carts.Remove(listItem[i]);

                await _context.SaveChangesAsync();

                // update quantity of product in store

                result.Stock = result.Stock - listItem[i].Quantity;
               
                _context.Products.Update(result);
                
                // save 
                
                await _context.SaveChangesAsync();

                _context.OrderDetails.Add(orderItem);

                await _context.SaveChangesAsync();

            }

            return true;
        }

        // this method can add multiple quantity of product in page product details or update quantity of product in your cart;

        public async Task<bool> addorupdateMulProduct(int Id, int quan, bool isUpdate)
        {
            var listItem = await _context.Carts.Where(x => x.UserId.Equals(_repoUser.getUserID())).ToListAsync();

            var result = _context.Products.FirstOrDefault(x => x.Id == Id);

            var index = await FindProductByIdInCart(Id);

            if (result == null)
            {
                return false;
            }
            else
            {
                if (result.Stock < quan)
                {

                    return false;
                }
                else
                {
                    if (index != -1)
                    {
                        // update quantity of product in cart

                        if (isUpdate == true)
                        {
                            listItem[index].Quantity = quan;

                        }
                        // add multiple quantity of product in cart
                        else
                        {
                            listItem[index].Quantity = listItem[index].Quantity + quan;

                        }
                        _context.Carts.Update(listItem[index]);

                    }

                    // if this product not exist in cart, create new this item in cart

                    else
                    {

                        var newItem = new Cart { ProductId = Id, Quantity = quan, UnitPrice = result.UnitPrice, UserId = _repoUser.getUserID() };

                        _context.Carts.Add(newItem);
                    }
                    // save
                    await _context.SaveChangesAsync();


                }

                return true;
            }
        }
    }
}
