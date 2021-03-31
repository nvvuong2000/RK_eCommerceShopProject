
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize( UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            if (!roleManager.RoleExistsAsync("superadmin").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("superadmin"));
            }
            if (!roleManager.RoleExistsAsync("admin").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (!roleManager.RoleExistsAsync("user").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            //Seed Default User
            var defaultUser = new User
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0867537750",
              //  FullName = "Super Admin",
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.Count(u => u.Email == defaultUser.Email) == 0)
            {
                IdentityResult result = await userManager.CreateAsync(defaultUser, "Qpzm1092@");
                if (result.Succeeded)
                {
              
                    await userManager.AddToRoleAsync(defaultUser, "admin");
                    await userManager.AddToRoleAsync(defaultUser, "user");
                }
            }

        }
    }
}
