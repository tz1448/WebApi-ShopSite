using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}