using Entities;

namespace Repositories
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> AddOrderItemAsync(OrderItem newOrderItem);
        Task<List<OrderItem>> GetAllOrderItemsAsync();
        Task<List<OrderItem>> GetAllOrderItemsByOrderIdAsync(int orderId);
    }
}