using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {

            return await _productRepository.GetAllProductsAsync();


        }
        public async Task<Product> GetProductByIdAsync(int id)
        {

            return await _productRepository.GetProductByIdAsync(id);


        }
        public async Task<Product> CreateProductAsync(Product product)
        {

            return await _productRepository.CreateProductAsync(product);

        }


    }
}
