using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
    // GET: api/<ProductsController>
    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get([FromQuery]  String? desc, [FromQuery]  int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categories )
    {

            List < Product > products= await _productService.GetAllProductsAsync(desc, minPrice, maxPrice,categories );

            return products == null ? NotFound() : Ok(products);
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {

            Product product = await _productService.GetProductByIdAsync(id);
           return product == null ? NoContent() : Ok(product);
        }

    // POST api/<ProductsController>
    [HttpPost]
    public async  Task<ActionResult<Product>> Post([FromBody] Product newProduct)
    {
            Product product = await _productService.CreateProductAsync(newProduct);
            return product == null ? NoContent() : Ok(product);
        }

  
}
}
