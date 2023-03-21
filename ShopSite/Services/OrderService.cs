using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> getAllOrdersAsync()
        {
            return await _orderRepository.getAllOrdersAsync();


        }
        public async Task<Order> getOrderByIdAsync(int id)
        {
            return await _orderRepository.getOrderByIdAsync(id);



        }
        public async Task<Order> createOrderAsync(Order newOrder)
        {
            return await _orderRepository.createOrderAsync(newOrder);


        }



    }
}
