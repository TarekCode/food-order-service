using food_order_service.Data_layer.DataModels;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> UpdateConfig(int id, string key, string value)
        {
            var config = await _foodServiceContext.SystemConfiguration.FindAsync(id);

            if (config != null)
            {
                config.Key = key;
                config.Value = value;

                await _foodServiceContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ConfigOption>> GetAll()
        {
            return await _foodServiceContext.SystemConfiguration.ToListAsync();
        }
    }
}
