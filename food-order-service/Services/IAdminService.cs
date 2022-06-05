namespace food_order_service.Services
{
    public interface IAdminService
    {
        Task AddNewConfigurationValue(string key, string value);
    }
}
