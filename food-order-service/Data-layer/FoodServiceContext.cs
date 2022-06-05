using food_order_service.Data_layer.DataModels;
using Microsoft.EntityFrameworkCore;

namespace food_order_service.Data_layer
{
    public class FoodServiceContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ItemOption> ItemOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ItemModification> ItemModifications { get; set; }
        public DbSet<ConfigOption> SystemConfiguration { get; set; }

        public FoodServiceContext(DbContextOptions<FoodServiceContext> options) : base(options)
        {

        }
    }
}
