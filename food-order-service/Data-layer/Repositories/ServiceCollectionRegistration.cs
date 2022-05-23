namespace food_order_service.Data_layer.Repositories
{
    public static class ServiceCollectionRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
        }
    }
}
