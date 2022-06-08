using food_order_service.Data_layer.DataModels;
using Microsoft.EntityFrameworkCore;

namespace food_order_service.Data_layer
{
    public class FoodServiceContext : DbContext
    {
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<ItemOption> ItemOptions => Set<ItemOption>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<ItemModification> ItemModifications => Set<ItemModification>();
        public DbSet<ConfigOption> SystemConfiguration => Set<ConfigOption>();

        public FoodServiceContext(DbContextOptions<FoodServiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConfigOption>()
                .HasIndex(x => x.Key)
                .IsUnique();
        }
    }
}
