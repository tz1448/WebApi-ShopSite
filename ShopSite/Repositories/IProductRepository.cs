using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync(String? desc, int? minPrice, int? maxPrice, int?[] categories);
        Task<Product> GetProductByIdAsync(int id);
    }
}