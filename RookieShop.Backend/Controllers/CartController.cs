using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDF _repoUser;
        private readonly ICart _repo;
        

        public CartController(ApplicationDbContext context, IUserDF repoUser, ICart repo)
        {
            _context = context;
            _repoUser = repoUser;
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<List<Cart>> Index()
        {


            var userId = _repoUser.getUserID();
            try
            {
                
               var list = await _repo.myCart(userId);


                return list;
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }      
        [HttpGet("{id}")]
     
        public async Task<IActionResult> Buy(int id)
        {
            var Userid = _repoUser.getUserID();
            var listItem = await _context.Carts.Where(x => x.userId == Userid).ToListAsync();


            var index = await FindID(id);
            if (index != -1)
            {
                listItem[index].quantity = listItem[index].quantity + 1;
            }
            else
            {
                var result = _context.Products.FirstOrDefault(x => x.Id == id);
                if (result == null)
                {
                    return NotFound();
                }
                var newItem = new Cart { productId = id, quantity = 1, unitPrice = result.unitPrice, userId = Userid };
                _context.Carts.Add(newItem);
            }
            await _context.SaveChangesAsync();
            return Ok(StatusCodes.Status200OK);
            //  return RedirectToAction("Index");
            //try
            //{

            //    var list = await _repo.AddProductIntoCart(id);


            //    return Ok(StatusCodes.Status200OK);

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

        }
        [HttpGet("find/{id}")]
        public async  Task<int> FindID(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem =  await _context.Carts.Where(x => x.userId == userId).ToListAsync();

            for (int i = 0; i < listItem.Count; i++)
            {

                if (listItem[i].productId == id)
                {
                    return i;
                }
            }
            return -1;
        }
        [HttpGet("total")]
        public async Task<decimal> TotalBill()
        {
            decimal total = 0;
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem = await _context.Carts.Where(x => x.userId == userId).ToListAsync();

            for (int i = 0; i < listItem.Count; i++)
            {

                total += listItem[i].unitPrice * listItem[i].quantity;
            }
            return total;
        }

        [HttpGet("/remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
           
            try
            {

                var result = await _repo.RemoveItem(id);


                return Ok(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return null;
            }


        }
        [HttpGet("checkout")]
        public async  Task<IActionResult> Checkout()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem = await _context.Carts.Where(x => x.userId == userId).ToListAsync();

            var order = new Order()
            {
                userId = userId,
                dateOrdered = DateTime.Now,
                status = 0,
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
          
            for (int i = 0; i < listItem.Count; i++)
            {
                var result = _context.Products.FirstOrDefault(x => x.Id == listItem[i].productId);

                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                var orderItem = new OrderDetails()
                {

                    Id = randomNumber,
                    orderId = order.Id,
                    productId = listItem[i].productId,
                    quantity = listItem[i].quantity,
                    unitPrice = listItem[i].unitPrice,
                    productName = result.productName,
                };
                _context.OrderDetails.Add(orderItem);
                _context.Carts.Remove(listItem[i]);
                await _context.SaveChangesAsync();
            }

 

            return Ok();



        }
    }
}
