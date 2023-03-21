using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}