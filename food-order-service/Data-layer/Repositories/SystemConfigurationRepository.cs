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

        public async Task SaveConfig(string key, string value)
        {
            var config = await _foodServiceContext.SystemConfiguration.Where(x => x.Key == key).FirstOrDefaultAsync();

            if (config == null)
            {
                _foodServiceContext.SystemConfiguration.Add(new ConfigOption()
                {
                    Key = key,
                    Value = value
                });
            }
            else
            {
                config.Value = value;
            }

            await _foodServiceContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ConfigOption>> GetAll()
        {
            return await _foodServiceContext.SystemConfiguration.ToListAsync();
        }
    }
}
