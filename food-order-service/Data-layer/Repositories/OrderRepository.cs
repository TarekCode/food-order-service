using food_order_service.Data_layer.DataModels;
using Microsoft.EntityFrameworkCore;

#nullable disable warnings

namespace food_order_service.Data_layer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodServiceContext _foodServiceContext;

        public OrderRepository(FoodServiceContext foodServiceContext)
        {
            _foodServiceContext = foodServiceContext;
        }

        public async Task<Order?> GetOrder(int id)
        {
            Order? item = await _foodServiceContext.Orders.AsNoTracking()
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.ItemModifications)
                .FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<int> SaveNewOrder(Order order)
        {
            foreach (var orderItem in order.OrderItems)
            {
                //do not save navigation property
                orderItem.MenuItem = null;
            }

            _foodServiceContext.Orders.Add(order);

            await _foodServiceContext.SaveChangesAsync();

            return order.Id;
        }

        public async Task<IEnumerable<Order>> GetOrders(string? status = null)
        {
            if (status == null)
            {
                return await _foodServiceContext.Orders.AsNoTracking().ToListAsync();
            }

            return await _foodServiceContext.Orders.AsNoTracking()
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.ItemModifications)
                .Where(x => x.OrderStatus == status).ToListAsync();
        }

        public async Task<bool> SetOrderStatus(int orderId, string status)
        {
            var order = await _foodServiceContext.Orders.FindAsync(orderId);
            if (order == null) { return false; }

            order.OrderStatus = status;

            await _foodServiceContext.SaveChangesAsync();

            return true;
        }
    }
}
