
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
        public Task<bool> addProduct([FromForm] ProductCreateRequest product);
        public Task<bool> updateProduct(int id, [FromForm] ProductCreateRequest product);
        public Task<List<ProductListVM>> getListProductAsync();
        public Task<ProductDetailsVM> getProductAsync(int? id);
        public Task<List<ProductListVM>> getListProductbyCategoryID(int? id);
        public Task<List<Product>> SortDescOrderByPrice();
        public Task<List<Product>> SortDescAscByPrice();
        public Task<List<Product>> SortDescOrderByName();
        public Task<List<Product>> SortAscByName();
        public Task<Product> searchbyName(string? keyword);
        public Task<List<ProductListVM>> getlistProductNeedRating(string userId);
        public Task<bool> ratingProduct(RatingProductRequest request);


    }
}
