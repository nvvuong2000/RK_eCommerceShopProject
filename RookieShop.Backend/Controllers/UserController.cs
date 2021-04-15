using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
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
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context, IUserDF repo)
        {
            _repo = repo;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                string userId = _repo.getUserID();
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
