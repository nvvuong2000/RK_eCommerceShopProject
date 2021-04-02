using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Shared;
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
        [HttpGet("/find/{id}")]
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


    }
}
