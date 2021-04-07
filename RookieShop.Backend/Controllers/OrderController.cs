﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDF _repoUser;
        private readonly IOrder _repo;

        public OrderController(ApplicationDbContext context, IUserDF repoUser, IOrder repo)
        {
            _context = context;
            _repo = repo;
            _repoUser = repoUser;
        }
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<IEnumerable<Order>>> GetListOrder()
        {

            var userId = _repoUser.getUserID();
            try
            {

                var list = await _repo.myOrderList();


                return list;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderbyID(int id)
        {

            var userId = _repoUser.getUserID();
            try
            {

                var list = await _repo.myOrderListbyId(id);


                return list;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }

    }
}
