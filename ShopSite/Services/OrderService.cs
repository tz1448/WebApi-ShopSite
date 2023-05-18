using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Extensions.Logging;

using Repositories;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
         ILogger<OrderService> _logger; 
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository= productRepository;
           _logger = logger;

        }

        public async Task<List<Order>> getAllOrdersAsync()
        {
            return await _orderRepository.getAllOrdersAsync();


        }
        public async Task<Order> getOrderByIdAsync(int id)
        {
            return await _orderRepository.getOrderByIdAsync(id);



        }
        public async Task<Order> createOrderAsync(Order newOrder) {

            int sum = 0;
            foreach (var item in newOrder.OrderItems)
            {
                Product product = await _productRepository.GetProductByIdAsync(item.ProductId);

                sum += (product.Price * item.Quntity);
            }
            if (newOrder.Ordersum != sum)
            {
                _logger.LogInformation("client changed sum check him out");
                newOrder.Ordersum = sum;
            }

            return await _orderRepository.createOrderAsync(newOrder);


        }



    }
}
