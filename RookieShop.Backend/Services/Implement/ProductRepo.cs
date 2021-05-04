using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{
    public class ProductRepo : IProduct
    {
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _config;

        private readonly IUserDF _repoUser;

        private IHostingEnvironment _hostingEnv;

        public ProductRepo(ApplicationDbContext context, IUserDF repoUser, IHostingEnvironment hostingEnv, IConfiguration config)
        {
            _context = context;

            _hostingEnv = hostingEnv;

            _repoUser = repoUser;

            _config = config;


        }

        // This method add new product;

        public async Task<bool> addProduct([FromForm] ProductRequest product)
        {
            var newProduct = new Product()
            {
                CategoryId = product.CategoryId,

                ProductName = product.ProductName,

                ProviderId = product.ProviderId,

                Description = product.Description,

                Stock = product.Stock,

                UnitPrice = product.UnitPrice,

                Status = product.Status,

                IsNew = product.IsNew,

                DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")),

                DateUpated = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")),
            };
            // add product 

            _context.Products.Add(newProduct);
            // save product

            await _context.SaveChangesAsync();

            var productId = newProduct.Id;
            try
            {
                // Save Image list of product

                foreach (var formFile in product.FormFiles)
                {
                    // Random to avoid the same name 

                    Random getrandom = new Random();

                    int random = getrandom.Next(1, 99999);


                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", random.ToString() + formFile.FileName);

                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyTo(stream);

                        }
                    }
                    // create new image product
                    var ProductImage = new ProductImages
                    {
                        ProductID = productId,

                        PathName = Path.Combine("/images/" + random.ToString() + formFile.FileName),

                        IsDefault = product.FormFiles.IndexOf(formFile) == 0 ? true : false,

                        CaptionImage = "The image illustrates the product " + product.ProductName,

                    };
                    // add image product

                    _context.ProductImages.Add(ProductImage);

                    // save 

                    await _context.SaveChangesAsync();

                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        // this method get product list for user with product availability: status is true and stock > 0

        public async Task<List<ProductListVM>> getListProductAsync()
        {
            var productList = await _context.Products.Include(p => p.ProductImages).Where(p => p.Status == true && p.Stock > 0)

            .Select(x => new ProductListVM
            {
                ProductId = x.Id,

                ProductName = x.ProductName,

                UnitPrice = x.UnitPrice,

                IsNew = x.IsNew,

                CategoryId = x.CategoryId,

                CategoryName = x.Category.CategoryName,

                Stock = x.Stock,

                Status = x.Status,

                ProviderId = x.ProviderId,

                ImgDefault = x.ProductImages.Where(img => img.IsDefault == true).Select(img => _config["Host"] + img.PathName).FirstOrDefault(),
            }).ToListAsync();

            return productList;
        }

        // this method get product list for admin

        public async Task<List<ProductListVM>> getListProductbyAdminAsync()
        {
            var productList = await _context.Products.Include(p => p.ProductImages)
            .Select(x => new ProductListVM
            {
                ProductId = x.Id,

                ProductName = x.ProductName,

                UnitPrice = x.UnitPrice,

                IsNew = x.IsNew,

                CategoryId = x.CategoryId,

                CategoryName = x.Category.CategoryName,

                Stock = x.Stock,

                Status = x.Status,

                ProviderId = x.ProviderId,

                ImgDefault = x.ProductImages.Where(img => img.IsDefault == true).Select(img => _config["Host"] + img.PathName).FirstOrDefault(),

            }).ToListAsync();

            return productList;
        }

        // this method get product list by category Id
        public async Task<List<ProductListVM>> getListProductbyCategoryID(int id)
        {
            var productList = await _context.Products.Include(p => p.ProductImages).Select(x => new ProductListVM
            {
                CategoryId = x.CategoryId,

                ProductId = x.Id,

                ProductName = x.ProductName,

                UnitPrice = x.UnitPrice,

                IsNew = x.IsNew,

                ImgDefault = x.ProductImages.Where(img => img.IsDefault == true).Select(img => _config["Host"] + img.PathName).FirstOrDefault()

            }).Where(p => p.CategoryId == id).ToListAsync();

            return productList;
        }

        // this method get product by product Id ,images list and  list rating of product 

        public async Task<ProductDetailsVM> getProductAsync(int id)
        {
            var product = _context.Products.Include(p => p.ProductImages).Include(p => p.Category).Include(p => p.RattingProduct).Select(p => new ProductDetailsVM()
            {
                Id = p.Id,

                ProductName = p.ProductName,

                CategoryName = p.Category.CategoryName,

                ProviderId = p.ProviderId,

                CategoryId = p.CategoryId,

                Stock = p.Stock,

                UnitPrice = p.UnitPrice,

                Description = p.Description,

                DateCreated = p.DateCreated,

                IsNew = p.IsNew,

                Status = p.Status,

                PathName = p.ProductImages.Select(img => _config["Host"] + @img.PathName).ToList(),

                Alt = p.ProductImages.Select(img => img.CaptionImage).ToList(),

                UserId = p.RattingProduct.Select(r => r.User.CustomerName).ToList(),

                NumberRating = p.RattingProduct.Select(r => r.NumberRating).ToList(),

                DateRated = p.RattingProduct.Select(r => r.Date).ToList(),

                Rating = p.Rating,

            }).Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                return null;
            }

            return product;

        }
        // This method is update some property of product and update all image list if at least 1 image is changed ;

        public async Task<bool> updateProduct(int id, [FromForm] ProductRequest product)
        {
            var productEdit = await _context.Products.Include(img => img.ProductImages).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (productEdit == null)
            {
                return false;
            }
            else
            {
                productEdit.ProductName = product.ProductName;

                productEdit.CategoryId = product.CategoryId;

                productEdit.Description = product.Description;

                productEdit.UnitPrice = product.UnitPrice;

                productEdit.Stock = product.Stock;

                productEdit.ProviderId = product.ProviderId;

                productEdit.IsNew = product.IsNew;

                productEdit.Status = product.Status;

                product.DateUpdated = Convert.ToDateTime(DateTime.Now.ToString());

                await _context.SaveChangesAsync();

                // if no change images list return state update success

                if (product.FormFiles == null)
                {
                    return true;
                }
                else
                {
                    // else : remove all old images list

                    try
                    {
                        var productImagesEdit = productEdit.ProductImages.ToList();

                        if (productImagesEdit != null)
                        {
                            for (int i = 0; i < productImagesEdit.Count; i++)
                            {
                                if (DeleteFile(productImagesEdit[i].PathName) == true)
                                {
                                    var img = await _context.ProductImages.FindAsync(productImagesEdit[i].ID);

                                    if (img == null)
                                    {
                                        return false;
                                    }

                                    _context.ProductImages.Remove(img);

                                    await _context.SaveChangesAsync();
                                }
                            }

                        }
                        // and add new images list 

                        foreach (var formFile in product.FormFiles)
                        {
                            Random getrandom = new Random();

                            int random = getrandom.Next(1, 99999);

                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", random.ToString() + formFile.FileName);

                            if (formFile.Length > 0)
                            {
                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);

                                }
                            }
                            var ProductImage = new ProductImages
                            {
                                ProductID = id,

                                PathName = Path.Combine("/images/" + random.ToString() + formFile.FileName),

                                IsDefault = product.FormFiles.IndexOf(formFile) == 0 ? true : false,
                                CaptionImage = "The image illustrates the product" + product.ProductName,

                            };
                            // add 
                            _context.ProductImages.Add(ProductImage);
                            // save
                            await _context.SaveChangesAsync();
                        }
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

            }
        }

        // This method will delete file image in root image

        public bool DeleteFile(string file)
        {

            string webRootPath = _hostingEnv.WebRootPath;

            var fullPath = Path.Combine(webRootPath+ file);


            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            return true;
        }

        // this medthod search product by name with name product has containt the keyword
        public async Task<List<Product>> searchByName(string keyword)
        {
            var product = await _context.Products.Include(p => p.ProductImages).Where(p => p.ProductName.Contains(keyword)).OrderByDescending(p => p.ProductName).ToListAsync();

            return product;
        }

        // this method return list product need evaluated with coditions: customer was recevied the order 

        public async Task<List<ProductListVM>> getListProductNeedRating()
        {
            // a query get list product when the order have status was recevied (include a result query productberated under)

            string userID = _repoUser.getUserID();

            var query = await (from od in _context.OrderDetails

                               join o in _context.Order on od.OrderId equals o.Id

                               join p in _context.Products on od.ProductId equals p.Id

                               join pm in _context.ProductImages on p.Id equals pm.ProductID

                               // status is 2 is means customer was recevied the order

                               where (o.Status == 2 && pm.IsDefault == true && o.UserId.Equals(userID))

                               select new ProductListVM
                               {
                                   ProductId = p.Id,

                                   ProductName = p.ProductName,

                                   ImgDefault = _config["Host"] + pm.PathName,

                               }).ToListAsync();


            // query  get list product be rated by cusomter before

            var productberated = await (
                         from p in _context.Products

                         join pm in _context.ProductImages on p.Id equals pm.ProductID

                         join pr in _context.RattingProduct on p.Id equals pr.ProductId

                         where (pm.IsDefault == true && pr.UserId.Equals(userID))

                         select new ProductListVM
                         {

                             ProductId = p.Id,

                             ProductName = p.ProductName,

                             ImgDefault = _config["Host"] + pm.PathName,

                         }).ToListAsync();

            // and list product has not been evaluated

            var NotInRecord = query.Where(p => !productberated.Any(p2 => p2.ProductId == p.ProductId)).ToList();

            return NotInRecord;
        }

        // this medthod evaluated for product 

        public async Task<bool> ratingProduct(RatingProductRequest request)
        {
            // create new ratings

            Random getrandom = new Random();

            int random = getrandom.Next(1, 999);

            var rating = new RattingProduct()
            {
                Id = random,

                UserId = _repoUser.getUserID(),

                ProductId = request.ProductId,

                NumberRating = request.NumberRating,

                Date = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")),

            };
            // add

            _context.RattingProduct.Add(rating);
            // save

            _context.SaveChanges();

            // after save then update ratings for this product     

            var product = _context.Products.Where(p => p.Id == request.ProductId).FirstOrDefault();

            product.Rating = avgRatings(request.ProductId);

            _context.SaveChanges();

            return true;

        }

        public double avgRatings(int productId)
        {
            int totalStar = _context.RattingProduct.Where(r => r.ProductId == productId).Sum(r => r.NumberRating);

            int number = _context.RattingProduct.Where(r => r.ProductId == productId).Count();

            double avg = (double)totalStar / number;

            return avg;
        }
    }

}
