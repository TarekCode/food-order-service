using food_order_service.Data_layer.DataModels;
using Microsoft.EntityFrameworkCore;

namespace food_order_service.Data_layer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodServiceContext _foodServiceContext;

        public OrderRepository(FoodServiceContext foodServiceContext)
        {
            _foodServiceContext = foodServiceContext;
        }

        public async Task SaveNewOrder(Order order)
        {
            _foodServiceContext.Orders.Add(order);

            await _foodServiceContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(string? status = null)
        {
            if (status == null)
            {
                return await _foodServiceContext.Orders.AsNoTracking().ToListAsync();
            }

            return await _foodServiceContext.Orders.Where(x => x.OrderStatus == status).AsNoTracking().ToListAsync();
        }
    }
}
