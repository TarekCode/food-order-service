using food_order_service.Models;

namespace food_order_service.Services
{
    public interface IOrderService
    {
        Task CreateNewOrder(OrderRequest orderRequest);
    }
}
