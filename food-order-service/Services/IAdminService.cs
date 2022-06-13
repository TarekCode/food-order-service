using food_order_service.Data_layer.DataModels;

namespace food_order_service.Services
{
    public interface IAdminService
    {
        Task SaveConfigurationValue(string key, string value);
        Task<IEnumerable<ConfigOption>> GetSystemConfigurationValues();
    }
}
