using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<List<Category>> GetAllCategoryAsync()
        {

            return await _categoryRepository.GetAllCategoryAsync();


        }


        public async Task<Category> GetCategoryByIdAsync(int id)
        {

            return await _categoryRepository.GetCategoryByIdAsync(id);


        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.CreateCategoryAsync(category);

        }

    }
}
