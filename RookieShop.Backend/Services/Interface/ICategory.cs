
using Microsoft.AspNetCore.Mvc;
using RookieShop.Backend.Models;
using RookieShop.Shared.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
    public interface ICategory
    {
        public Task<bool> addCategory(Category category);
        public Task<bool> updateCategory(int? id, CategoryRequest category);
        public Task<List<Category>> getListCategory();

        public Task<Category> getCategorybyID(int id);

    }
}
