using food_order_service.Data_layer.DataModels;
using food_order_service.Models;

namespace food_order_service.Services
{
    public class MenuResponseBuilder : IMenuResponseBuilder
    {
        public MenuItemResponse BuildMenuResponse(MenuItem menuItem)
        {
            List<ItemOptionResponse> itemOptionResponses = new List<ItemOptionResponse>();

            if (menuItem.ItemOptions != null)
            {
                foreach (var item in menuItem.ItemOptions)
                {
                    itemOptionResponses.Add(new ItemOptionResponse()
                    {
                        Name = item.Name,
                        IncludedByDefault = item.IncludedByDefault,
                        AdditionalCost = item.AdditionalCost
                    });
                }
            }

            return new MenuItemResponse()
            {
                Title = menuItem.Title,
                Description = menuItem.Description,
                MinutesToPrepare = (short)menuItem.PreparationTime.TotalMinutes,
                Price = menuItem.Price,
                ItemOptions = itemOptionResponses
            };
        }
    }
}
