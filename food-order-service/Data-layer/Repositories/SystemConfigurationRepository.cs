using food_order_service.Data_layer.DataModels;

namespace food_order_service.Data_layer.Repositories
{
    public class SystemConfigurationRepository : ISystemConfigurationRepository
    {
        private readonly FoodServiceContext _foodServiceContext;

        public SystemConfigurationRepository(FoodServiceContext foodServiceContext)
        {
            _foodServiceContext = foodServiceContext;
        }

        public async Task AddNewConfig(string key, string value)
        {
            _foodServiceContext.SystemConfiguration.Add(new ConfigOption()
            {
                Key = key,
                Value = value
            });

            await _foodServiceContext.SaveChangesAsync();
        }
    }
}
