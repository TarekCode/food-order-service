using System;

namespace food_order_service.Models
{
    public class MenuItemRequest
    {
        public int MenuItemId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public IEnumerable<ItemOptionRequest> ItemOptions { get; set; } = Enumerable.Empty<ItemOptionRequest>();
    }

    public class ItemOptionRequest
    {
        public int ItemOptionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IncludedByDefault { get; set; }
        public decimal AdditionalCost { get; set; }
    }
}
