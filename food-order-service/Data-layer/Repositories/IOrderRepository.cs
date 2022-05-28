using food_order_service.Data_layer.DataModels;

namespace food_order_service.Data_layer.Repositories
{
    public interface IOrderRepository
    {
        Task SaveNewOrder(Order order);
        Task<IEnumerable<Order>> GetOrders(string? status = null);
        Task<Order?> GetOrder(int id);
    }
}
