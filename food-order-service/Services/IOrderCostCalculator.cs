using food_order_service.Data_layer.DataModels;

namespace food_order_service.Services
{
    public interface IOrderCostCalculator
    {
        Task CalculateCost(Order order);
    }
}
