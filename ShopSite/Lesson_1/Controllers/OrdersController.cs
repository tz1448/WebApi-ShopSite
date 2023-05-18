using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using DTO;
using System.Collections.Generic;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
   [Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
        IOrderService _orderService;
        IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
    // GET: api/<OrdersController>
    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> Get()
    {

           List< Order> orders = await _orderService.getAllOrdersAsync();

            List<OrderDto> ordersDto = _mapper.Map<List<Order>, List<OrderDto>>(orders);

           return orders == null ? NotFound() : Ok(ordersDto);
    }

    // GET api/<OrdersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> Get(int id)
    {
            Order order = await _orderService.getOrderByIdAsync(id);
            OrderDto orderDto = _mapper.Map<Order,OrderDto>(order);
            return orderDto == null ? NoContent() : Ok(orderDto);
        }

    // POST api/<OrdersController>
    [HttpPost]
    public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto orderDto)
    {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            Order orderCreated = await _orderService.createOrderAsync(order);
            OrderDto orderCreatedDto = _mapper.Map<Order, OrderDto>(orderCreated);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, orderCreatedDto);

        }

   
    
}
}
