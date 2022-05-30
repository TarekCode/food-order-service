using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;
using food_order_service.Models;

namespace food_order_service.Services
{
    public class OrderResponseBuilder : IOrderResponseBuilder
    {
        private readonly IMenuRepository _menuRepository;

        public OrderResponseBuilder(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<OrderResponse> BuildOrderData(Order order)
        {
            List<OrderItemResponse> orderItems = new List<OrderItemResponse>();

            if (order.OrderItems != null)
            {
                foreach (OrderItem item in order.OrderItems)
                {
                    MenuItem menuItem = item.MenuItem ?? await GetMenuItem(item.MenuItemId);
                    IEnumerable<ItemModificationResponse> modifications = new List<ItemModificationResponse>();

                    if (item.ItemModifications != null && menuItem.ItemOptions != null)
                    {
                        modifications = BuildModificationList(menuItem.ItemOptions, item.ItemModifications);
                    }

                    orderItems.Add(new OrderItemResponse()
                    {
                        BasePrice = menuItem.Price,
                        MenuItemName = menuItem.Title,
                        Modifications = modifications
                    });
                }
            }

            return new OrderResponse()
            {
                OrderId = order.Id,
                CustomerName = order.CustomerName,
                PhoneNumber = order.PhoneNumber,
                OrderTotal = order.OrderTotal,
                OrderItems = orderItems
            };
        }

        private IEnumerable<ItemModificationResponse> BuildModificationList(IEnumerable<ItemOption> itemOptions, IEnumerable<ItemModification> itemModifications)
        {
            List<ItemModificationResponse> resp = new List<ItemModificationResponse>();

            foreach (ItemModification modification in itemModifications)
            {
                ItemOption? itemOption = itemOptions.FirstOrDefault(x => x.Id == modification.ItemOptionId);

                if (itemOption != null)
                {
                    resp.Add(new ItemModificationResponse()
                    {
                        ItemName = itemOption.Name,
                        ChangeType = modification.ChangeType,
                        ModificationCost = modification.ModificationCost
                    });
                }
            }

            return resp;
        }

        private async Task<MenuItem> GetMenuItem(int id)
        {
            var item = await _menuRepository.GetById(id);

            if (item == null)
            {
                throw new ArgumentException($"Could not find menu item with id: {id}");
            }

            return item;
        }
    }
}
