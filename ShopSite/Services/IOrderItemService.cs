using Entities;

namespace Services
{
    public interface IOrderItemService
    {
        Task<OrderItem> AddOrderItemAsync(OrderItem newOrderItem);
        Task<List<OrderItem>> GetAllOrderItemsAsync();
        Task<List<OrderItem>> GetAllOrderItemsByOrderIdAsync(int orderId);
    }
}