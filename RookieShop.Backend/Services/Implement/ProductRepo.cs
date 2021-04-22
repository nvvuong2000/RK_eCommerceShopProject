using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{
    public class ProductRepo : IProduct
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDF _repoUser;
        private IHostingEnvironment _hostingEnv;
        public ProductRepo(ApplicationDbContext context, IHostingEnvironment hostingEnv, IUserDF repoUser)
        {
            _context = context;
            _hostingEnv = hostingEnv;
            _repoUser = repoUser;
        }
        public async Task<bool> addProduct([FromForm] ProductCreateRequest product)
        {
            var newProduct = new Product()
            {
                categoryId = product.categoryID,
                productName = product.productName,
                providerId = product.providerID,
                description = product.description,
                stock = product.stock,
                unitPrice = product.unitPrice,
                status = product.status,
                isNew = product.isNew

            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            var productId = newProduct.Id;
            try
            {

                foreach (var formFile in product.FormFiles)
                {
                    Random getrandom = new Random();
                    int random = getrandom.Next(1, 99999);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", random.ToString()+formFile.FileName);
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyToAsync(stream);

                        }
                    }
                    var ProductImage = new ProductImages
                    {
                        ProductID = productId,

                        pathName = Path.Combine("/images/" + random.ToString()+ formFile.FileName),

                        isDefault = false,
                        captionImage = "Hình ảnh minh họa cho sản phẩm " + product.productName,

                    };
                    _context.ProductImages.Add(ProductImage);
                    await _context.SaveChangesAsync();


                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public async Task<List<ProductListVM>> getListProductAsync()
        {
            var productList =await _context.Products.Include(p => p.ProductImages)
            .Select(x => new ProductListVM
            {
                productID = x.Id,
                productName = x.productName,
                unitPrice = x.unitPrice,
                isNew = x.isNew,
                categoryId = x.categoryId,
                categoryName = x.Category.categoryName,
                stock = x.stock,


                imgDefault = x.ProductImages.Where(img => img.isDefault == true).Select(img => "https://localhost:44341" + img.pathName).FirstOrDefault(),
            }).ToListAsync();

            return productList;
        }

        public async Task<List<ProductListVM>> getListProductbyCategoryID(int? id)
        {
            var productList = await _context.Products.Include(p => p.ProductImages).Select(x => new ProductListVM
            {
                categoryId = x.categoryId,
                productID = x.Id,
                productName = x.productName,
                unitPrice = x.unitPrice,
                isNew = x.isNew,
                imgDefault = x.ProductImages.Where(img => img.isDefault == true).Select(img => "https://localhost:44341" + img.pathName).FirstOrDefault()
            }).Where(p => p.categoryId == id).ToListAsync();
            return productList;
        }

        public async Task<ProductDetailsVM> getProductAsync(int? id)
        {
            var product = _context.Products.Include(p => p.ProductImages).Include(p => p.Category).Include(p => p.RattingProduct).Select(p => new ProductDetailsVM()
            {
                Id = p.Id,
                productName = p.productName,
                categoryName = p.Category.categoryName,
                providerId = p.providerId,
                categoryId = p.categoryId,
                stock = p.stock,
                unitPrice = p.unitPrice,
                description = p.description,
                DateCreated = p.DateCreated,
                isNew = p.isNew,
                status = p.status,
                pathName = p.ProductImages.Select(img => "https://localhost:44341" + @img.pathName).ToList(),
                alt = p.ProductImages.Select(img => img.captionImage).ToList(),
                userId = p.RattingProduct.Select(r => r.User.customerName).ToList(),
                numberRating = p.RattingProduct.Select(r => r.numberRating).ToList(),
                dateRated = p.RattingProduct.Select(r => r.date).ToList(),


                rating = p.rating,

            }).Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                return null;
                
            }

            
            return product;

        }

        public async Task<List<Product>> SortDescAscByPrice()
        {

            var productList = await _context.Products.Include(p => p.ProductImages).ToListAsync();
            return productList;
        }


        public async Task<List<Product>> SortDescOrderByPrice()
        {

            var productList = await _context.Products.Include(p => p.ProductImages).OrderByDescending(p => p.unitPrice).ToListAsync();
            return productList;
        }

        public async Task<bool> updateProduct(int id, [FromForm] ProductCreateRequest product)
        {
            var productEdit = await _context.Products.Include(img => img.ProductImages).Where(p => p.Id == id).FirstOrDefaultAsync();
            if (productEdit == null)
            {
                return false;
            }
            else
            {
                productEdit.categoryId = product.categoryID;
                productEdit.description = product.description;
                productEdit.productName = product.productName;
                productEdit.unitPrice = product.unitPrice;
                productEdit.stock = product.stock;
                productEdit.providerId = product.providerID;
               


                

                await _context.SaveChangesAsync();
                if(product.FormFiles == null)
                {
                    return true;
                }
                else
                {
                    try
                    {
                        var productImagesEdit = productEdit.ProductImages.ToList();
                        if (productImagesEdit != null)
                        {
                            for (int i = 0; i < productImagesEdit.Count; i++)
                            {
                                if (DeleteFile(productImagesEdit[i].pathName) == true)
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
                        foreach (var formFile in product.FormFiles)
                        {
                            Random getrandom = new Random();
                            int random = getrandom.Next(1, 99999);
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
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
               

                }
               

                return true;

            }
        }

        public Task<bool> updateProduct(int? id, ProductCreateRequest product)
        {
            throw new NotImplementedException();
        }
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

        public async Task<List<Product>> SortDescOrderByName()
        {
            var productList = await _context.Products.Include(p => p.ProductImages).OrderByDescending(p => p.productName).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> SortAscByName()
        {
            var productList = await _context.Products.Include(p => p.ProductImages).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> searchbyName(string keyword)
        {
            var product =await  _context.Products.Include(p => p.ProductImages).Where(p => p.productName.Contains(keyword)).OrderByDescending(p => p.productName).ToListAsync();
            return product;
        }

        public async Task<List<ProductListVM>> getlistProductNeedRating(string userId)
        {

            var query = await (from od in _context.OrderDetails
                               join o in _context.Order on od.orderId equals o.Id
                               join p in _context.Products on od.productId equals p.Id
                               join pm in _context.ProductImages on p.Id equals pm.ProductID
                               where (o.status == 2 && pm.isDefault == true && o.userId.Equals(userId))
                               select new ProductListVM
                               {
                                   productID = p.Id,
                                   productName = p.productName,
                                   imgDefault = "https://localhost:44341" + pm.pathName,
                               }).ToListAsync();
            var productberated = await (
                         from p in _context.Products
                         join pm in _context.ProductImages on p.Id equals pm.ProductID
                         join pr in _context.RattingProduct on p.Id equals pr.productID
                         where (pm.isDefault == true && pr.userID.Equals(userId))
                         select new ProductListVM
                         {
                             productID = p.Id,
                             productName = p.productName,
                             imgDefault = "https://localhost:44341"+pm.pathName,
                         }).ToListAsync();
            var NotInRecord = query.Where(p => !productberated.Any(p2 => p2.productID == p.productID)).ToList();

            return NotInRecord;
        }

        public async Task<bool> ratingProduct(RatingProductRequest request)
        {
            Random getrandom = new Random();
            int random = getrandom.Next(1, 999);
            var rating = new RattingProduct()
            {
                Id = random,
                userID = _repoUser.getUserID(),
                productID = request.productId,
                numberRating = request.numberRating,

            };
            _context.RattingProduct.Add(rating);
            _context.SaveChanges();
            int totalStar = _context.RattingProduct.Where(r=>r.productID==request.productId).Sum(r => r.numberRating);
            int number = _context.RattingProduct.Where(r => r.productID == request.productId).Count();
            double avg = totalStar / number;
            var product = _context.Products.Where(p => p.Id == request.productId).FirstOrDefault();
            product.rating = avg;
            _context.SaveChanges();
            return true;

        }
    }

}
