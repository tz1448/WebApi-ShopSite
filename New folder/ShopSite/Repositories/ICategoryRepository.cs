using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {

        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<List<Category>> GetAllCategoryAsync();
    }
}