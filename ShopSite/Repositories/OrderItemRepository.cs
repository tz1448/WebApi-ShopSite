using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {


        StoryDbContext _storyDbContext;
        public OrderItemRepository(StoryDbContext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync()
        {

            return await _storyDbContext.OrderItems.Include(OrderItem => OrderItem.Order).Include(OrderItem => OrderItem.Product).ToListAsync();


        }
        public async Task<List<OrderItem>> GetAllOrderItemsByOrderIdAsync(int orderId)
        {

            return await _storyDbContext.OrderItems.Where(orderItem => orderItem.OrderId == orderId).ToListAsync();





        }
        public async Task<OrderItem> AddOrderItemAsync(OrderItem newOrderItem)
        {
            await _storyDbContext.OrderItems.AddAsync(newOrderItem);
            await _storyDbContext.SaveChangesAsync();
            return newOrderItem;

        }


    }
}
