using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using System.Collections.Generic;
using AutoMapper;
using DTO;
using System.Collections;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }

        // GET: api/<CategoriesController>

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {

            List<Category> categories = await _categoryService.GetAllCategoryAsync();
            List<CategoryDto> categoriesDto = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return categories == null ? NotFound() : Ok(categoriesDto);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            Category category = await _categoryService.GetCategoryByIdAsync(id);
            return category == null ? NoContent() : Ok(_mapper.Map<Category, CategoryDto>(category));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto newCategoryDto)
        {
            Category newCategory = _mapper.Map<CategoryDto, Category>(newCategoryDto);
            Category category= await _categoryService.CreateCategoryAsync(newCategory);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, _mapper.Map< Category,CategoryDto>(category));
          

        }

        
    }
}
