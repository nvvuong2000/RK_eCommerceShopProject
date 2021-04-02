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
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public const string CARTKEY = "cart";
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> Index()
        {
            if (HttpContext.Session.GetString(CARTKEY) == null)
            {
                return null;
            }
            else
            {
                var value = HttpContext.Session.GetString(CARTKEY);
                var jsonvalue = value;
                var value2 = JsonConvert.DeserializeObject<List<Cart>>(jsonvalue);
                return value2;
            }

        }
        
        [HttpGet("{id}")]
        //[Authorize(Roles = "user")]
        public IActionResult Buy(int id)
        {
            // Get User ID
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            ProductVM product = new ProductVM();
            // Kiểm tra xem tồn tại Session cart chưa?
            // Nếu chưa khởi tạo session cart với sản phẩm đầu tiên
            if (HttpContext.Session.GetString(CARTKEY) == null)
            {
                List<Cart> cart = new List<Cart>();
                var result = _context.Products.FirstOrDefault(x => x.productID == id);

                cart.Add(new Cart { productID = id, quantity = 1, unitPrice = result.unitPrice });

                HttpContext.Session.SetString(CARTKEY, JsonConvert.SerializeObject(cart));

            }
            else
            {
                var value = HttpContext.Session.GetString(CARTKEY);
                var jsonvalue = value;
                var value2 = JsonConvert.DeserializeObject<List<Cart>>(jsonvalue);
                var index = FindID(id);
                if (index == -1)
                {
                    List<Cart> cart = new List<Cart>();
                    var result = _context.Products.FirstOrDefault(x => x.productID == id);
                    value2.Add(new Cart { productID = id, quantity = 1, unitPrice = result.unitPrice });
                }
                else
                {
                    value2[index].quantity = value2[index].quantity + 1;

                }
                HttpContext.Session.SetString(CARTKEY, JsonConvert.SerializeObject(value2));
            }
            return RedirectToAction("Index");
        }
        [HttpGet("find/{id}")]
        public int FindID(int id)
        {
            var value = HttpContext.Session.GetString(CARTKEY);
            var jsonvalue = value;
            var value2 = JsonConvert.DeserializeObject<List<Cart>>(jsonvalue);

            for (int i = 0; i < value2.Count; i++)
            {

                if (value2[i].productID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        [HttpGet("total")]
        public decimal TotalBill()
        {
            var value = HttpContext.Session.GetString(CARTKEY);
            var jsonvalue = value;
            var value2 = JsonConvert.DeserializeObject<List<Cart>>(jsonvalue);
            decimal total = 0;

            for (int i = 0; i < value2.Count; i++)
            {

                total += value2[i].unitPrice * value2[i].unitPrice;
            }
            return total;
        }

        [HttpGet("/remove/{id}")]
        public IActionResult Remove(int id)
        {
            var value = HttpContext.Session.GetString(CARTKEY);
            var jsonvalue = value;
            if (jsonvalue == null)
            {
                return NotFound();
            }
            var value2 = JsonConvert.DeserializeObject<List<Cart>>(jsonvalue);
            int index = FindID(id);
            if (index == -1)
            {
                return NotFound();

            }
            value2.RemoveAt(index);
            HttpContext.Session.SetString(CARTKEY, JsonConvert.SerializeObject(value2));
            return Redirect("Index");

        }
        [HttpGet("checkout")]
        public async  Task<IActionResult> Checkout()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            var value = HttpContext.Session.GetString(CARTKEY);
            var jsonvalue = value;
            if (jsonvalue == null)
            {
                return NotFound();
            }
            var value2 = JsonConvert.DeserializeObject<List<Cart>>(jsonvalue);
            
            var order = new Order()
            {
                userID = Userid,
                dateOrdered = DateTime.Now,
                status = 0,
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            for (int i = 0; i < value2.Count; i++)
            {
                var result = _context.Products.FirstOrDefault(x => x.productID == value2[i].productID);

                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                var orderItem = new OrderDetails()
                {
                    
                    orderdetailsID = randomNumber,
                    orderID = order.orderID,
                    productID = value2[i].productID,
                    quantity = value2[i].quantity,
                    unitPrice = value2[i].unitPrice,
                    productName = result.productName,
                };
                _context.OrderDetails.Add(orderItem);
                await _context.SaveChangesAsync();
            }
          
            return Redirect("Index");



        }
    }
}
