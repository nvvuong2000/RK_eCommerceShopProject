using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{
    public class ProductRepo : IProduct
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnv;
        public ProductRepo(ApplicationDbContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }
        public async Task<bool> addProduct([FromForm] ProductCreateRequest product)
        {
            var newProduct = new Product()
            {
                categoryID = product.categoryID,
                productName = product.productName,
                providerID = product.providerID,
                description = product.description,
                stock = product.stock,
                unitPrice = product.unitPrice,
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            var productID = newProduct.productID;
            try
            {

                foreach (var formFile in product.FormFiles)
                {
                    Guid getrandom = new Guid();
                    
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", getrandom + formFile.FileName);
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

                        pathName = Path.Combine("/images/" + getrandom + formFile.FileName),

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

        public async Task<List<Product>> getListProductAsync()
        {
            var productList = await _context.Products.Include(p=>p.ProductImages).ToListAsync();
                //.Select(x => new ProductListVM { productID = x.productID, productName = x.productName, unitPrice =x.unitPrice, isNew = x.isNew})

            return productList;
        }

        public async Task<List<Product>> getListProductbyCategoryID(int? id)
        {
            var productList = await _context.Products.Include(p => p.ProductImages).Where(p=>p.categoryID ==id).ToListAsync();
            return productList;
        }

        public async Task<Product> getProductAsync(int? id)
        {
            var product =  _context.Products.Include(p => p.ProductImages).Include(p => p.Category).Include(p => p.RattingProduct).Where(p => p.productID == id).FirstOrDefault();
            if(product == null)
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

            var productList = await _context.Products.Include(p => p.ProductImages).OrderByDescending(p=>p.unitPrice).ToListAsync();
            return productList;
        }

        public async Task<bool> updateProduct(int id, [FromForm] ProductCreateRequest product)
        {
            var productEdit = await _context.Products.Include(img => img.ProductImages).Where(p => p.productID == id).FirstOrDefaultAsync();
            if (productEdit == null)
            {
                return false;
            }
            else
            {
                productEdit.categoryID = product.categoryID;
                productEdit.description = product.description;
                productEdit.productName = product.productName;
                productEdit.unitPrice = product.unitPrice;
                productEdit.stock = product.stock;
                productEdit.providerID = product.providerID;


                var productImagesEdit = await _context.ProductImages.Where(p => p.ProductID == id).ToListAsync();
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
                    return true;
                }
                catch (Exception)
                {
                    return false;
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
            var productList = await _context.Products.Include(p => p.ProductImages).OrderByDescending(p=>p.productName).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> SortAscByName()
        {
            var productList = await _context.Products.Include(p => p.ProductImages).ToListAsync();
            return productList;
        }

        public async Task<Product> searchbyName(string keyword)
        {
            var product = _context.Products.Include(p => p.ProductImages).Where(p => p.productName.Contains(keyword)).OrderByDescending(p => p.productName).FirstOrDefault();
            return product;
        }
    }

}
