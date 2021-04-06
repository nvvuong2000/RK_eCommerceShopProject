
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
        public Task<List<Product>> getListProductAsync();
        public Task<Product> getProductAsync(int? id);
        public Task<List<ProductListVM>> getListProductbyCategoryID(int? id);
        public Task<List<ProductListVM>> SortDescOrderByPrice();
        public Task<List<ProductListVM>> SortDescAsyncByPrice();


    }
}
