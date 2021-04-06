using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnv;

        public OrderController(ApplicationDbContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<IEnumerable<Order>>> GetListOrder()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;

            var listOrder = await _context.Order.Include(o=>o.OrderDetails).Include(o=>o.OrderDetails).Where(x => x.userID == Userid).ToListAsync();
            return listOrder;

        }
        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderbyID(int id)
        {
            var result = await _context.OrderDetails.Where(od => od.orderID == id).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return result;

        }

    }
}
