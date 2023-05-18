using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using System.Collections.Generic;
using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
    {
        IProductService _productService;
        IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
   
     // GET: api/<ProductsController>
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> Get([FromQuery]  String? desc, [FromQuery]  int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categories )
    {

            List <Product> products= await _productService.GetAllProductsAsync(desc, minPrice, maxPrice,categories );
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return products == null ? NotFound() : Ok(productsDto);
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {

            Product product = await _productService.GetProductByIdAsync(id);
            ProductDto  ProductDto = _mapper.Map<Product, ProductDto> (product);
            return product == null ? NoContent() : Ok(ProductDto);
        }

    // POST api/<ProductsController>
    [HttpPost]
    public async  Task<ActionResult<ProductDto>> Post([FromBody] ProductDto newProductDto)
    {
            Product product = _mapper.Map<ProductDto, Product>(newProductDto);
            Product newProduct = await _productService.CreateProductAsync(product);
            ProductDto ProductDto = _mapper.Map<Product, ProductDto>(newProduct);
            return newProduct == null ? NoContent() : Ok(ProductDto);

         
        }


    }
}
