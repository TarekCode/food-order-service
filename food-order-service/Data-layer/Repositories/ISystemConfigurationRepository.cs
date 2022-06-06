using food_order_service.Data_layer.DataModels;

namespace food_order_service.Data_layer.Repositories
{
    public interface ISystemConfigurationRepository
    {
        Task AddNewConfig(string key, string value);
        Task<bool> UpdateConfig(int id, string key, string value);
        Task<IEnumerable<ConfigOption>> GetAll();
    }
}
