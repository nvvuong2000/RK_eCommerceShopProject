using RookieShop.Backend.Models;
using RookieShop.Shared.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
   public interface IUserDF
    {
        public string getUserID();
        
        public Task<UserInfo> getInfoUser();
        
        public Task<List<UserListInfo>> getListUser();
    }
}
