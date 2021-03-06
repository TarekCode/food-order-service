using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;

namespace food_order_service.Services
{
    public class AdminService : IAdminService
    {
        private readonly ISystemConfigurationRepository _systemConfigurationRepository;

        public AdminService(ISystemConfigurationRepository systemConfigurationRepository)
        {
            _systemConfigurationRepository = systemConfigurationRepository;
        }

        public async Task SaveConfigurationValue(string key, string value)
        {
            await _systemConfigurationRepository.SaveConfig(key, value);
        }

        public async Task<IEnumerable<ConfigOption>> GetSystemConfigurationValues()
        {
            return await _systemConfigurationRepository.GetAll();
        }
    }
}
