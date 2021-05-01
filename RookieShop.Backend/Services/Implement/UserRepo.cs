using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{
    public class UserRepo : IUserDF
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
      
        private readonly ApplicationDbContext _context;
        
        public UserRepo(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
           
            _context = context;
        }
        // this method get user id after login success 

        public string getUserID()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        // this method get information ab user and only user have roles is admin may access admin site
        public async Task<UserInfo> getInfoUser()
        {
            string id = getUserID();
           
            var info = await (from u in _context.Users
                              
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              
                              join r in _context.Roles on ur.RoleId equals r.Id
                              
                              where u.Id.Equals(id) && r.Name=="admin"
                              
                              select new UserInfo
                              {
                                  UserId = u.Id,
                                 
                                  UserName = u.CustomerName,
                                  
                                  UserAddress = u.Address,
                                  
                                  UserTel = u.PhoneNumber,
                                  
                                  Roles = r.Name
                              }).FirstOrDefaultAsync();
           
            return info;

        }

        // this method get information ab customer 
        public async Task<List<UserListInfo>> getListUser()
        {
            var Listinfo = await (from u in _context.Users
                                 
                                  join od in _context.Order on u.Id equals od.UserId
                                  
                                  group od by new { od.UserId, u.CustomerName, u.Email, u.PhoneNumber } into users
                                  
                                  select new UserListInfo
                                  {
                                      UserId = users.Key.UserId,
                                  
                                      FullName = users.Key.CustomerName,
                                      
                                      UserEmail = users.Key.Email,
                                      
                                      UserPhone = users.Key.PhoneNumber,
                                      
                                      CountOrder = users.Count(),
                                      
                                      TotalOrder = users.Sum(x => x.Total),

                                  }).ToListAsync();
            
            return Listinfo;


        }
    }
}
