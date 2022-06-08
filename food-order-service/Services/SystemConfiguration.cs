using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;

namespace food_order_service.Services
{
    public class SystemConfiguration : ISystemConfiguration
    {
        private readonly ISystemConfigurationRepository _configurationRepository;
        private Dictionary<string, string> _configOptions;

        public SystemConfiguration(ISystemConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;

            _configOptions = new Dictionary<string, string>();
        }

        public async Task<decimal> TaxRate()
        {
            return decimal.Parse(await GetConfigValue("tax_rate"));
        }

        public async Task<bool> AcceptingOrders()
        {
            return bool.Parse(await GetConfigValue("accepting_orders"));
        }

        private async Task<string> GetConfigValue(string key)
        {
            if (_configOptions.Count() == 0)
            {
                _configOptions = (await _configurationRepository.GetAll()).ToDictionary(x => x.Key, x => x.Value);
            }

            return _configOptions[key];
        }
    }

    public interface ISystemConfiguration
    {
        Task<decimal> TaxRate();
        Task<bool> AcceptingOrders();
    }
}
