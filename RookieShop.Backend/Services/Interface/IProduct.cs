
using Microsoft.AspNetCore.Mvc;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
    public interface IProduct
    {
        public Task<bool> addProduct([FromForm] ProductRequest product);

        public Task<bool> updateProduct(int id, [FromForm] ProductRequest product);
        
        public Task<List<ProductListVM>> getListProductAsync();
        
        public Task<ProductDetailsVM> getProductAsync(int id);
        
        public Task<List<ProductListVM>> getListProductbyAdminAsync();
        
        public Task<List<ProductListVM>> getListProductbyCategoryID(int id);
              
        public Task<List<Product>> searchByName(string keyword);
        
        public Task<List<ProductListVM>> getListProductNeedRating();
        
        public Task<bool> ratingProduct(RatingProductRequest request);

        public double avgRatings(int productId);


    }
}
