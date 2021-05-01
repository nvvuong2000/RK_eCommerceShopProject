using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CartController : ControllerBase
    {

        private readonly ICart _repo;
        public CartController(ICart repo)
        {

            _repo = repo;
        }
        [HttpGet]

        public async Task<List<CartVM>> Index()
        {

            var list = await _repo.myCart();

            return list;
        }
        [HttpGet("add/{id}")]
        public async Task<bool> Buy(int id)

        {

            var result = await _repo.AddProductIntoCart(id);

            return result;



        }



        [HttpGet("addquantity/{Id}/number/{quan}/isUpdate/{isUpdate}")]
        public async Task<IActionResult> AddQuantity(int Id, int quan, bool isUpdate)
        {

            var result = await _repo.addorupdateMulProduct(Id, quan, isUpdate);
            return Ok(result);

        }

        [HttpGet("total")]

        public async Task<decimal> TotalBill()
        {

            var result = await _repo.TotalBill();

            return result;

        }

        [HttpGet("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {


            var result = await _repo.RemoveItem(id);

            return Ok(result);



        }
        [HttpGet("checkout")]
        public async Task<IActionResult> Checkout()
        {

            var result = await _repo.Checkout();

            return Ok(result);


        }
    }

}