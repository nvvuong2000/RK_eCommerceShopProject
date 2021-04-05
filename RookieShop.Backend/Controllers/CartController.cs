using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
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
        public const string CARTKEY = "cart";
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Index()
        {

           
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            if (Userid != null)
            {
                
                var listItem = await _context.Carts.Include(c=>c.Product).Include(p=>p.Product.ProductImages).Where(x => x.userID == Userid).ToListAsync();

                return Ok(listItem);
            }
            return null;
        }      
        [HttpGet("{id}")]
     
        public async Task<IActionResult> Buy(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem = await _context.Carts.Where(x => x.userID == Userid).ToListAsync();
           
            
            var index = await FindID(id);
            if (index != -1)
            {
                listItem[index].quantity = listItem[index].quantity + 1;
            }
            else
            {
                var result = _context.Products.FirstOrDefault(x => x.productID == id);
                if (result == null)
                {
                    return NotFound();
                }
                var newItem = new Cart { productID = id, quantity = 1, unitPrice = result.unitPrice, userID = Userid };
                _context.Carts.Add(newItem);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet("find/{id}")]
        public async  Task<int> FindID(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem =  await _context.Carts.Where(x => x.userID == Userid).ToListAsync();

            for (int i = 0; i < listItem.Count; i++)
            {

                if (listItem[i].productID == id)
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
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem = await _context.Carts.Where(x => x.userID == Userid).ToListAsync();

            for (int i = 0; i < listItem.Count; i++)
            {

                total += listItem[i].unitPrice * listItem[i].quantity;
            }
            return total;
        }

        [HttpGet("/remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem = await _context.Carts.Where(x => x.userID == Userid).ToListAsync();

            int  index = await FindID(id);
            if (index == -1)
            {
                return NotFound();

            }
            _context.Carts.Remove(listItem[index]);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet("checkout")]
        public async  Task<IActionResult> Checkout()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var listItem = await _context.Carts.Where(x => x.userID == Userid).ToListAsync();

            var order = new Order()
            {
                userID = Userid,
                dateOrdered = DateTime.Now,
                status = 0,
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
          
            for (int i = 0; i < listItem.Count; i++)
            {
                var result = _context.Products.FirstOrDefault(x => x.productID == listItem[i].productID);

                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                var orderItem = new OrderDetails()
                {

                    orderdetailsID = randomNumber,
                    orderID = order.orderID,
                    productID = listItem[i].productID,
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
