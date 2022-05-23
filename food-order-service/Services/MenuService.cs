using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;

namespace food_order_service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<MenuItem> GetMenuItem(int id)
        {
            MenuItem? result = await _menuRepository.GetById(id);

            if (result == null)
            {
                throw new ArgumentException($"Could not find menu item with Id '{id}'");
            }

            return result;
        }
    }
}
