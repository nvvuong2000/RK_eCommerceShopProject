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

        private readonly IOrder _repo;

        public OrderController(IOrder repo)
        {

            _repo = repo;

        }
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetMyListOrder()
        {

            var list = await _repo.myOrderList();

            return list;

        }
        
        
        [HttpGet("/getorderlist")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetListOrder()
        {
            var list = await _repo.getAllOrder();

            return list;


        }
      
        
        [HttpGet("{id}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<OrderVm>> GetOrderbyID(int id)
        {
            var list = await _repo.getorDetailsbyOrderId(id);

            return Ok(list);
        }
        
        
        [HttpGet("listOrder/{id}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<OrderVm>> GetListOrderbyuserID(string id)
        {
            var list = await _repo.getOrderListofCus(id);

            return Ok(list);


        }
        [HttpGet("updateSttOrder/{id}")]
        [Authorize(Roles = "user")]
        public bool UpdateSttOdCs(int id)
        {

            var result = _repo.updateSttOrdrerCs(id);

            return result;
        }
       
        
        [HttpPost("updateSttOrderad")]
        [Authorize(Roles = "admin")]
        public bool UpdateSttOdAd(StatusOrderRequest statusRequest)
        {
            var result = _repo.updateSttOrdrerAd(statusRequest);

            return result;
        }
    }
}
