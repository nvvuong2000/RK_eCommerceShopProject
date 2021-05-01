using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{
    public class ProviderRepo : IProvider
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProviderVM>> GetProviderList()
        {
            var providerList =  _context.Providers.Select(p => new ProviderVM
            {
                ProviderId = p.Id,

                ProviderName = p.ProviderName,
            }).ToList();

            return providerList;
        }
    }
}
