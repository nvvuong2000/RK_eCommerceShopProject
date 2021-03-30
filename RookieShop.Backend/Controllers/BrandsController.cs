using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<categoryVm>>> GetCategories()
        {
            return await _context.Categories
                .Select(x => new categoryVm { Id = x.categoryID, Name = x.categoryName })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<categoryVm>> Getcategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryVm = new categoryVm
            {
                Id = category.categoryID,
                Name = category.categoryName,
            };

            return categoryVm;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Putcategory(int id, categoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.categoryName = categoryCreateRequest.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<categoryVm>> Postcategory(categoryCreateRequest categoryCreateRequest)
        {
            var category = new Category
            {
                categoryName = categoryCreateRequest.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcategory", new { id = category.categoryID }, new categoryVm { Id = category.categoryID, Name = category.categoryName });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Deletecategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
