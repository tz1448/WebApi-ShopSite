using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {


        StoryDbContext _storyDbContext;
        public ProductRepository(StoryDbContext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {

            return await _storyDbContext.Products.Include(product => product.Category).ToListAsync();


        }
        public async Task<Product> GetProductByIdAsync(int id)
        {

           
            //return await _storyDbContext.Products.Include(product=>product.Category).FindAsync(id);
            return await _storyDbContext.Products.FindAsync(id);

        }
        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            await _storyDbContext.Products.AddAsync(newProduct);
            await _storyDbContext.SaveChangesAsync();
            return newProduct;

        }




    }
}

