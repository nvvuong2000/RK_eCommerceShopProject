using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services
{
    public class UserServices : IUserServices

    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private string id = "";
        public UserServices(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
          

        }
        public string getUserID()
        {
            return id;

        }
    }
}
