using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
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

    public class UserController : ControllerBase
    {
        private readonly IUserDF _repo;
        public UserController(IUserDF repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public IActionResult Index()
        {
                string userId = _repo.getUserID();

                return Ok(userId);
        }
        [HttpGet("infoUser")]
        public async Task<IActionResult> infoUser()
        {
                var user = await _repo.getInfoUser();

                return Ok(user);
        }
        [HttpGet("listUser")]
        public async Task<ActionResult<IList<UserListInfo>>> ListinfoUser()
        {
            var user = await _repo.getListUser();

            return Ok(user);
        }
    }
}
