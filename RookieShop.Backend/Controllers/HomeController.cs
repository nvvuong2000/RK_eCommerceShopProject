using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services;
using RookieShop.Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
       private readonly IUserServices _user;

        public HomeController(ILogger<HomeController> logger)

        {
            // UserServices user
            _logger = logger;
          // _user = user;
        }

        public async Task<IActionResult> IndexAsync()
        {
          
            
            return View();
          
        }
        public IActionResult GetUserID()
        {

            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var id = claims.FirstOrDefault(s => s.Type == "sub")?.Value;
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }
        protected int GetUserId()
        {
            return int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
