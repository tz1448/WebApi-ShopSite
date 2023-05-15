using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {

        IOrderItemService _orderItemService;
        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        // GET: api/<OrderItemsController>
        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> Get()
        {

            List<OrderItem> orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return orderItems == null ? NotFound() : Ok(orderItems);
        }

        // GET api/<OrderItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrderItem>>> Get(int id)
        {
            List<OrderItem> orderItems = await _orderItemService.GetAllOrderItemsByOrderIdAsync(id);
            return orderItems == null ? NoContent() : Ok(orderItems);
        }

        // POST api/<OrderItemsController>
        [HttpPost]
        public async Task<ActionResult<OrderItem>> Post([FromBody] OrderItem newOrderItem)
        {

            OrderItem orderItem = await _orderItemService.AddOrderItemAsync(newOrderItem);

            return CreatedAtAction(nameof(Get), new { id = orderItem.Id }, orderItem);

        }
    }















}

