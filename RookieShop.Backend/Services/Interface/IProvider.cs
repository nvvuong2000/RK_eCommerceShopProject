
using RookieShop.Shared.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
   public interface IProvider
    {
        public Task<List<ProviderVM>> GetProviderList();
    }
}
