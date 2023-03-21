using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> createOrderAsync(Order newOrder);
        Task<List<Order>> getAllOrdersAsync();
        Task<Order> getOrderByIdAsync(int id);
    }
}