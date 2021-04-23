using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProviderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProviderController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ProviderVM>> Index()
        {
            try
            {

                var providerList =  await _context.Providers.Select(p => new ProviderVM
                {
                    providerId = p.Id,
                    providerName = p.providerName,
                }).ToListAsync();


                return providerList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
