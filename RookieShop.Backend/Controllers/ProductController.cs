using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]

    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;
        private readonly ApplicationDbContext _context;
        private readonly IUserDF _repoUser;
        private IHostingEnvironment _hostingEnv;

        public ProductController(ApplicationDbContext context, IUserDF repoUser,IProduct repo, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _repoUser = repoUser;
            _repo = repo;
            _hostingEnv = hostingEnv;
        }
        // GET: api/<Product>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListVM>> GetAsync()
        {
            try
            {
                var list = await _repo.getListProductAsync();
                
                return Ok(list);

              
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

        // GET api/<Product>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDetailsVM>> Get(int id)
        {
            try
            {
                var list = await _repo.getProductAsync(id);

                return Ok(list);


            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        

        
      
        [HttpPost("addProduct")]
        public async Task<IActionResult> addProduct([FromForm] ProductCreateRequest  file)
        {
            try
            {
                var list = await _repo.addProduct(file);
              
                return Ok(StatusCodes.Status201Created);


            }
            catch (Exception ex)
            {
                return null;
            }
         
        }
        // PUT api/<Product>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ProductCreateRequest product)
        {
            try
            {
                var list = await _repo.updateProduct(id,product);

                return Ok(StatusCodes.Status202Accepted);


            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        [HttpGet("deleteFile")]
        public bool DeleteFile(string file)
        {

           string webRootPath = _hostingEnv.WebRootPath;
            var fullPath = Path.Combine(webRootPath, file);
           

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                
            }
            return true;
        }
        [HttpGet("sortDescbyPrice")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> sortDescbyPrice()
        {
            try
            {
                var list = await _repo.SortDescOrderByPrice();

                return Ok(list);


            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
        [HttpGet("sortAscbyPrice")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> sortAscbyPrice()
        {
            try
            {
                var list = await _repo.SortDescAscByPrice();

                return Ok(list);


            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
            [HttpGet("sortDescbyName")]
            public async Task<ActionResult<Product>> sortDescbyName()
            {
                try
                {
                var list = await _repo.SortDescOrderByName();

                    return Ok(list);


                }
                catch (Exception ex)
                {
                return Ok(ex);
            }

            }
        [HttpGet("sortAscbyName")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> sortAscbyName()
            {
                try
                {
                var list = await _repo.SortAscByName();

                    return Ok(list);


                }
                catch (Exception ex)
                {
                return Ok(ex);
            }

            }
        [HttpPost("search")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> search(string keyword)
        {
            try
            {
                var product = await _repo.searchbyName(keyword);

                return Ok(product);


            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
        [HttpGet("/getID/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListVM>> getProductsbyCategoryId(int id)
        {
            try
            {
                var productslist= await _repo.getListProductbyCategoryID(id);

                return Ok(productslist);


            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
        [HttpGet("/rating")]
        [Authorize(Roles ="user")]
        public async Task<List<ProductListVM>> rating()
        {
            try
            {

                var userId = _repoUser.getUserID();
                var product = await _repo.getlistProductNeedRating(userId);
                return product;


            }
            catch (Exception ex)
            {
                return null;
            }

        }
        [HttpPost("/rating")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> rattingRequest(RatingProductRequest request)
        {
            try
            {


                var product = await _repo.ratingProduct(request);
                return Ok(StatusCodes.Status200OK);


            }
            catch (Exception ex)
            {
                throw new (ex.Message);
            }

        }


    }
}
