using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]


    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;

        public ProductController(IProduct repo)
        {

            _repo = repo;

        }
        // GET: api/<Product>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListVM>> GetAsync()
        {
            var list = await _repo.getListProductAsync();

            return Ok(list);

        }
        [HttpGet("ListProduct")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListVM>> GetListProductByAdmin()
        {
            var list = await _repo.getListProductbyAdminAsync();

            return Ok(list);
        }

        // GET api/<Product>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDetailsVM>> Get(int id)
        {
            try
            {
                var list = await _repo.getProductAsync(id);

                if (list == null)
                {
                    return Ok(null);
                }

                return Ok(list);



            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost("addProduct")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> addProduct([FromForm] ProductRequest product)
        {
            try
            {
                var result = await _repo.addProduct(product);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        // PUT api/<Product>/5
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put([FromForm] ProductRequest product)
        {
            try
            {
                var id = product.ProductId;

                var result = await _repo.updateProduct(id, product);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpPost("search")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> search(string keyword)
        {
            var list = await _repo.searchByName(keyword);

            return Ok(list);

        }
        [HttpGet("/getID/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListVM>> getProductsbyCategoryId(int id)
        {
            var productlist = await _repo.getListProductbyCategoryID(id);

            return Ok(productlist);

        }

        [HttpGet("rating")]

        [Authorize(Roles = "user")]
        public async Task<List<ProductListVM>> rating()
        {

            var list = await _repo.getListProductNeedRating();

            return list;

        }
        [HttpPost("rating")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> rattingRequest(RatingProductRequest request)
        {
            var result = await _repo.ratingProduct(request);

            return Ok(result);



        }


    }
}
