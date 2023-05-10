using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync(String? desc, int? minPrice, int? maxPrice,int?[] categories);
        Task<Product> GetProductByIdAsync(int id);
    }
}