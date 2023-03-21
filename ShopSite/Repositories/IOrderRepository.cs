using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> createOrderAsync(Order newOrder);
        Task<List<Order>> getAllOrdersAsync();
        Task<Order> getOrderByIdAsync(int id);
    }
}