﻿namespace food_order_service.Services
{
    public static class ServiceCollectionRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMenuService, MenuService>();
        }
    }
}
