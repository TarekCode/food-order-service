namespace food_order_service.Data_layer.Repositories
{
    public interface ISystemConfigurationRepository
    {
        Task AddNewConfig(string key, string value);
    }
}
