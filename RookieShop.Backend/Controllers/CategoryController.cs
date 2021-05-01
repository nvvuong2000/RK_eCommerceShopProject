using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public CategoryController(ICategory repo)
        {
            _repo = repo;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryRequest>> Create(CategoryRequest category)
        {
            Category newItem = new Category()
            {
                CategoryName = category.CategoryName,

                CategoryDescription = category.CategoryDescription,
            };

            var result = await _repo.addCategory(newItem);

            return Ok(result);
        }

        // POST: CategoryController/Create
        [HttpPut]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<Category>> Edit(Category category)
        {
            var result = await _repo.updateCategory(category);

            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Category>> Get()
        {

            return await _repo.GetCategoryList();

        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetbyID(int id)
        {
            var category = await _repo.getCategorybyID(id);

            if (category == null)
            {

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.NotFound);

                return Ok(result);
            }
            return Ok(category);
        }


    }
}
