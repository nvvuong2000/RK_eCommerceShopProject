using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Shared;
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
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnv;
        private int productID = 0;


        public ProductController(ApplicationDbContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }
        // GET: api/<Product>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAsync()
        {
            return await _context.Products.Include(p => p.ProductImages).ToListAsync();
               
        }

        // GET api/<Product>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {      
            return _context.Products.Where(x => x.productID == id).Include(p=>p.ProductImages).Include(p=>p.Category).FirstOrDefault();
        }
        

        
      
        [HttpPost("getFile")]
        public async Task<IActionResult> UploadFile([FromForm] FileModel  file)
        {
            var newProduct = new Product()
            {
                categoryID = file.categoryID,
                productName = file.productName,
                providerID = file.providerID,
                producerID = file.producerID,
                description = file.description,
                stock = file.stock,
                unitPrice = file.unitPrice,
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            productID = newProduct.productID;
            try
            {

                foreach (var formFile in file.FormFiles)
                {
                    Random getrandom = new Random();
                    int random = getrandom.Next(1, 99);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", random.ToString()+ formFile.FileName );
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyToAsync(stream);
                            
                        }
                    }
                    var ProductImage = new ProductImages
                    {
                        ProductID = productID,

                        pathName = Path.Combine("/images/"+ random.ToString() + formFile.FileName),

                        isDefault = false,
                        captionImage = "Hình ảnh minh họa cho sản phẩm " + file.productName,

                    };
                    _context.ProductImages.Add(ProductImage);
                    await _context.SaveChangesAsync();
                }
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return RedirectToAction("Index", "Home");
        }
        // PUT api/<Product>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] FileModel product)
        {
            var productEdit = await _context.Products.Include(img=>img.ProductImages).Where(p=>p.productID ==id).FirstOrDefaultAsync();
            if(productEdit == null)
            {
                return NotFound();
            }
            else
            {
                productEdit.categoryID = product.categoryID;
                productEdit.description = product.description;
                productEdit.productName = product.productName;
                productEdit.unitPrice = product.unitPrice;
                productEdit.stock = product.stock;
                productEdit.providerID = product.providerID;
                productEdit.producerID = product.producerID;

                var productImagesEdit  = await _context.ProductImages.Where(p => p.ProductID == id).ToListAsync();
                if(productImagesEdit != null)
                {
                    for (int i = 0; i < productImagesEdit.Count;i++)
                    {
                        if (DeleteFile(productImagesEdit[i].pathName) == true)
                        {
                            var img = await _context.ProductImages.FindAsync(productImagesEdit[i].ID);
                            if (img == null)
                            {
                                return NotFound();
                            }

                            _context.ProductImages.Remove(img);
                            await _context.SaveChangesAsync();
                        }
                    }
                   
                }

                await _context.SaveChangesAsync();
                try
                {

                    foreach (var formFile in product.FormFiles)
                    {
                        Random getrandom = new Random();
                        int random = getrandom.Next(1, 99);
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", random.ToString() + formFile.FileName);
                        if (formFile.Length > 0)
                        {
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyToAsync(stream);

                            }
                        }
                        var ProductImage = new ProductImages
                        {
                            ProductID = id,

                            pathName = Path.Combine("/images/" + random.ToString() + formFile.FileName),

                            isDefault = false,
                            captionImage = "Hình ảnh minh họa cho sản phẩm " + product.productName,

                        };
                        _context.ProductImages.Add(ProductImage);
                        await _context.SaveChangesAsync();
                    }
                    return StatusCode(StatusCodes.Status201Created);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return NoContent();

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
        // DELETE api/<Product>/5
    }
}
