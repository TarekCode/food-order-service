using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;

namespace food_order_service.Services
{
    public class OrderCostCalculator : IOrderCostCalculator
    {
        private readonly IMenuRepository _menuRepository;

        public OrderCostCalculator(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task CalculateCost(Order order)
        {
            order.OrderTotal = 0;

            if (order.OrderItems == null)
            {
                return;
            }

            foreach (OrderItem orderItem in order.OrderItems)
            {
                MenuItem menuItem = orderItem.MenuItem ?? await GetMenuItem(orderItem.MenuItemId);

                orderItem.Cost = menuItem.Price;

                if (orderItem.ItemModifications != null)
                {
                    foreach (ItemModification itemMod in orderItem.ItemModifications)
                    {
                        if (itemMod.ChangeType == "Added")
                        {
                            ItemOption? itemOption = menuItem.ItemOptions?.FirstOrDefault(x => x.Id == itemMod.ItemOptionId);

                            if (itemOption == null)
                            {
                                throw new ArgumentException($"Could not find item option with id: {itemMod.ItemOptionId}");
                            }

                            if (!itemOption.IncludedByDefault)
                            {
                                itemMod.ModificationCost = itemOption.AdditionalCost;
                                orderItem.Cost += itemMod.ModificationCost;
                            }
                        }
                    }
                }

                order.OrderTotal += orderItem.Cost;
            }
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
