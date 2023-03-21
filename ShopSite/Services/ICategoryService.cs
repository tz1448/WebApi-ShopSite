using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<List<Category>> GetAllCategoryAsync();
    }
}