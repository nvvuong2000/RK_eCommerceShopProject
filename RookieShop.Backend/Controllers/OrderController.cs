using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
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
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetMyListOrder()
        {
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
        [HttpGet("/getorderlist")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetListOrder()
        {
            try
            {

                var list = await _repo.getAllOrder();


                return list;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<OrderVm>> GetOrderbyID(int id)
        {
            try
            {

                var list = await _repo.getorDetailsbyOrderId(id);


                return Ok(list);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        [HttpGet("listOrder/{id}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<OrderVm>> GetListOrderbyuserID(string id)
        {


            try
            {

                var list = await _repo.getOrderListofCus(id);


                return Ok(list);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        [HttpGet("updateSttOrder/{id}")]
        [Authorize(Roles = "user")]
        public bool UpdateSttOdCs(int id)
        {

            
            try
            {

                var result = _repo.updateSttOrdrerCs(id);


                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        [HttpPost("updateSttOrderad")]
        [Authorize(Roles = "admin")]
        public bool UpdateSttOdAd(StatusOrderRequest statusRequest)
        {


            try
            {

                var result = _repo.updateSttOrdrerAd(statusRequest);


                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }

    }
}
