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

    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnv;
        public OrderController(ApplicationDbContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }
        // GET: api/<Product>
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Order>>>GetListOrder()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            return await _context.Order.Where(x=>x.userID==Userid).ToListAsync();

        }
        [HttpGet("{id}")]
        
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderbyID(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var Userid = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
           
            var result =  await _context.OrderDetails.Where(od=>od.orderID==id ).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return result;

        }

    }
}
