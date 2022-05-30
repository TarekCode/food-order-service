namespace food_order_service.Services
{
    public static class ServiceCollectionRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderCostCalculator, OrderCostCalculator>();
            services.AddScoped<IOrderResponseBuilder, OrderResponseBuilder>();
        }
    }
}
