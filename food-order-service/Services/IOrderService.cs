using food_order_service.Data_layer.DataModels;
using food_order_service.Models;

namespace food_order_service.Services
{
    public interface IOrderService
    {
        Task<int> CreateNewOrder(OrderRequest orderRequest);
        Task<IEnumerable<OrderResponse>> GetOpenOrders();
        Task UpdateOrderStatus(int orderId, string status);
    }
}
