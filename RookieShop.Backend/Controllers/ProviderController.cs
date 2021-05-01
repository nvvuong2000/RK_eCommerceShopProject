using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Services.Interface;
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
        private readonly IProvider _repo;
        public ProviderController(IProvider repo)
        {
            _repo = repo;

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
           
                var providerList = await _repo.GetProviderList();

                return Ok(providerList);

        }
    }
}
