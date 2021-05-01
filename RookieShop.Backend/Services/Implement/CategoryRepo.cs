using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Implement
{

    public class CategoryRepo : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Category> updateCategory(Category category)
        {
            var id = category.Id;

            var result = await _context.Categories.FindAsync(id);

            if (result == null)
            {
                return null;
            }

            result.CategoryName = category.CategoryName;

            result.CategoryDescription = category.CategoryDescription;

            _context.Categories.Update(result);

            _context.SaveChangesAsync();

            return category;

        }

        public async Task<Category> addCategory(Category category)
        {


            _context.Categories.Add(category);

            _context.SaveChangesAsync();

            return category;


        }

        public async Task<List<Category>> GetCategoryList()
        {
            var categoriesList = await _context.Categories.ToListAsync();

            return categoriesList;
        }

        public async Task<Category> getCategorybyID(int id)
        {
            var categories = await _context.Categories.FirstOrDefaultAsync(ca => ca.Id == id);

            return categories;
        }


    }
}
