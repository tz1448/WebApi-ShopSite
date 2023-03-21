using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        StoryDbContext _storyDbContext;
        public CategoryRepository(StoryDbContext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {

            return await _storyDbContext.Categories.ToListAsync();


        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {

            return await _storyDbContext.Categories.FindAsync(id);


        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _storyDbContext.Categories.AddAsync(category);
            await _storyDbContext.SaveChangesAsync();
            return category;

        }




    }
}
