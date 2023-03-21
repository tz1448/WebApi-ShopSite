using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
   [Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    // GET: api/<OrdersController>
    [HttpGet]
    public async Task<ActionResult<List<Order>>> Get()
    {

           List< Order> orders = await _orderService.getAllOrdersAsync();
           return orders == null ? NotFound() : Ok(orders);
    }

    // GET api/<OrdersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> Get(int id)
    {
            Order order = await _orderService.getOrderByIdAsync(id);
            return order == null ? NoContent() : Ok(order);
        }

    // POST api/<OrdersController>
    [HttpPost]
    public async Task<ActionResult<Order>> Post([FromBody] Order newOrder)
    {
            Order order = await _orderService.createOrderAsync(newOrder);

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);

        }

   
    
}
}
