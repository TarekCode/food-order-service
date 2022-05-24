using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;
using food_order_service.Models;

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

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            var result = await _menuRepository.GetAll();

            return result ?? Enumerable.Empty<MenuItem>();
        }

        public async Task AddOrUpdateMenuItem(MenuItemRequest menuItemRequest)
        {
            var entity = new MenuItem()
            {
                Id = menuItemRequest.MenuItemId,
                Title = menuItemRequest.Title,
                Price = menuItemRequest.Price,
                Description = menuItemRequest.Description
            };

            if (menuItemRequest.ItemOptions != null)
            {
                entity.ItemOptions = new List<ItemOption>();

                foreach (var item in menuItemRequest.ItemOptions)
                {
                    entity.ItemOptions.Add(new ItemOption()
                    {
                        Name = item.Name,
                        IncludedByDefault = item.IncludedByDefault,
                        AdditionalCost = item.AdditionalCost
                    });
                }
            }

            await _menuRepository.SaveMenuItem(entity);
        }
    }
}
