using food_order_service.Data_layer.DataModels;
using food_order_service.Models;

namespace food_order_service.Services
{
    public interface IMenuService
    {
        Task<MenuItemResponse> GetMenuItem(int id);
        Task<IEnumerable<MenuItemResponse>> GetAllMenuItems();
        Task AddOrUpdateMenuItem(MenuItemRequest menuItemRequest);
        Task DeleteMenuItem(int id);
    }
}
