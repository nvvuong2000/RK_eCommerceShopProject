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
         
        
        public async Task<bool> updateCategory(Category category)
        {
            var id = category.Id;
            var result = await _context.Categories.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            result.categoryName = category.categoryName;
            result.categoryDescription = category.categoryDescription;
            _context.Categories.Update(result);
            _context.SaveChangesAsync();
            return true;
           
        }

       public async Task<bool> addCategory(Category category)
        {
           

            _context.Categories.Add(category);
            return await _context.SaveChangesAsync()>0;
           
        }

        public async  Task<List<Category>> getListCategory()
        {
            var categoriesList =await _context.Categories.ToListAsync();
            return categoriesList;
        }

        public async Task<Category> getCategorybyID(int id)
        {
            var categories = await _context.Categories.FirstOrDefaultAsync(ca=>ca.Id==id);
            return categories;
        }
    }
}
