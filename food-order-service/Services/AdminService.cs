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

        public async Task AddNewConfigurationValue(string key, string value)
        {
            await _systemConfigurationRepository.AddNewConfig(key, value);
        }
    }
}
