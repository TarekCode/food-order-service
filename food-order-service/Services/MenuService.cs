using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;
using food_order_service.Models;

namespace food_order_service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMenuResponseBuilder _menuResponseBuilder;

        public MenuService(IMenuRepository menuRepository, IMenuResponseBuilder menuResponseBuilder)
        {
            _menuRepository = menuRepository;
            _menuResponseBuilder = menuResponseBuilder;
        }

        public async Task<MenuItemResponse> GetMenuItem(int id)
        {
            MenuItem? result = await _menuRepository.GetById(id);

            if (result == null)
            {
                throw new ArgumentException($"Could not find menu item with Id '{id}'.");
            }

            return _menuResponseBuilder.BuildMenuResponse(result);
        }

        public async Task<IEnumerable<MenuItemResponse>> GetAllMenuItems()
        {
            var result = await _menuRepository.GetAll();

            var mappedResult = result.Select(x => _menuResponseBuilder.BuildMenuResponse(x));

            return mappedResult ?? Enumerable.Empty<MenuItemResponse>();
        }

        public async Task AddOrUpdateMenuItem(MenuItemRequest menuItemRequest)
        {
            var entity = new MenuItem()
            {
                Id = menuItemRequest.MenuItemId,
                Title = menuItemRequest.Title,
                Price = menuItemRequest.Price,
                PreparationTime = new TimeSpan(0, menuItemRequest.PreparationMinutes, 0),
                Description = menuItemRequest.Description
            };

            if (menuItemRequest.ItemOptions != null)
            {
                entity.ItemOptions = new List<ItemOption>();

                foreach (var item in menuItemRequest.ItemOptions)
                {
                    entity.ItemOptions.Add(new ItemOption()
                    {
                        Id = item.ItemOptionId,
                        Name = item.Name,
                        IncludedByDefault = item.IncludedByDefault,
                        AdditionalCost = item.AdditionalCost
                    });
                }
            }

            await _menuRepository.SaveMenuItem(entity);
        }

        public async Task DeleteMenuItem(int id)
        {
            if (!await _menuRepository.DeleteMenuItem(id))
            {
                throw new ArgumentException($"Could not delete menu item with Id '{id}' because it does not exist.");
            }
        }
    }
}
