using food_order_service.Data_layer.DataModels;
using food_order_service.Models;

namespace food_order_service.Services
{
    public interface IMenuService
    {
        Task<MenuItem> GetMenuItem(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItems();
        Task AddOrUpdateMenuItem(MenuItemRequest menuItemRequest);
        Task DeleteMenuItem(int id);
    }
}
