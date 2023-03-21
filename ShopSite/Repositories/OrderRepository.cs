using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {

        StoryDbContext _storyDbContext;
        public OrderRepository(StoryDbContext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }



        public async Task<List<Order>> getAllOrdersAsync()
        {
            return await _storyDbContext.Orders.Include(order => order.User).ToListAsync();


        }
        public async Task<Order> getOrderByIdAsync(int id)
        {
            return await _storyDbContext.Orders.FindAsync(id);



        }
        public async Task<Order> createOrderAsync(Order newOrder)
        {
            await _storyDbContext.Orders.AddAsync(newOrder);
            await _storyDbContext.SaveChangesAsync();
            return newOrder;


        }

    }
}
