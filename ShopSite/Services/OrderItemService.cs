using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;
namespace Services
{
    public class OrderItemService : IOrderItemService
    {

        IOrderItemRepository _orderItemRepository;


        public OrderItemService(IOrderItemRepository orderItemRepositor)
        {
            _orderItemRepository = orderItemRepositor;
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync()
        {

            return await _orderItemRepository.GetAllOrderItemsAsync();


        }
        public async Task<List<OrderItem>> GetAllOrderItemsByOrderIdAsync(int orderId)
        {

            return await _orderItemRepository.GetAllOrderItemsByOrderIdAsync(orderId);




        }
        public async Task<OrderItem> AddOrderItemAsync(OrderItem newOrderItem)
        {

            return await _orderItemRepository.AddOrderItemAsync(newOrderItem);

        }


    }
}
