using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        // GET: api/<CategoriesController>

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {

            List<Category> categories = await _categoryService.GetAllCategoryAsync();
            return categories == null ? NotFound() : Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            Category category = await _categoryService.GetCategoryByIdAsync(id);
            return category == null ? NoContent() : Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category newCategory)
        {
            Category category= await _categoryService.CreateCategoryAsync(newCategory);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
          

        }

        
    }
}
