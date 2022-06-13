using food_order_service.Data_layer.DataModels;

namespace food_order_service.Data_layer.Repositories
{
    public interface ISystemConfigurationRepository
    {
        Task SaveConfig(string key, string value);
        Task<IEnumerable<ConfigOption>> GetAll();
    }
}
