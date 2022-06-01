using food_order_service.Data_layer.DataModels;
using food_order_service.Models;

namespace food_order_service.Services
{
    public interface IOrderResponseBuilder
    {
        Task<OrderResponse> BuildOrderResponse(Order order);
    }
}
