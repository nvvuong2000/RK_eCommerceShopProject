using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared;
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

    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;
        // GET: CategoryController
       

        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnv;
        private int productID = 0;


        public ProductController(ApplicationDbContext context, IHostingEnvironment hostingEnv, IProduct repo)
        {
            _context = context;
            _hostingEnv = hostingEnv;
            _repo = repo;
        }
        // GET: api/<Product>
        [HttpGet]
        public async Task<ActionResult<Product>> GetAsync()
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
        public async Task<ActionResult<Product>> Get(int id)
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
        

        
      
        [HttpPost("getFile")]
        public async Task<IActionResult> UploadFile([FromForm] ProductCreateRequest  file)
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

    }
}
