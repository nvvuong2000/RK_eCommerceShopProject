using RookieShop.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShop.Backend.Services.Interface
{
    public interface ICategory
    {
        public Task<Category> addCategory(Category category);
       
        public Task<Category> updateCategory(Category category);
        
        public Task<List<Category>> GetCategoryList();

        
        public Task<Category> getCategorybyID(int id);



    }
}
