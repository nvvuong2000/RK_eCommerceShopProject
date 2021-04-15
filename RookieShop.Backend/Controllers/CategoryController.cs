using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategory _repo;
        // GET: CategoryController
        public CategoryController(ICategory repo)
        {
            _repo = repo;
        }

        // POST: CategoryController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<bool> Create(CategoryRequest category)
        {
            try
            {
                Category newItem = new Category()
                {
                    categoryName = category.categoryName,
                };
                return await _repo.addCategory(newItem);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        // POST: CategoryController/Create
        [HttpPut]
        [Authorize(Roles = "admin")]

        public async Task<bool> Edit(int? id, CategoryRequest category)
        {
            try
            {
               
                return await _repo.updateCategory(id,category);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Category>> Get()
        {
            try
            {

                return await _repo.getListCategory();
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

    }
}
