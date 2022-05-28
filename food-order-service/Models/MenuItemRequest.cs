using System;
using System.ComponentModel.DataAnnotations;

namespace food_order_service.Models
{
    public class MenuItemRequest
    {
        public int MenuItemId { get; set; }
        [StringLength(128, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Range(0, 60)]
        public short PreparationMinutes { get; set; }
        [Range(0, 2000)]
        public decimal Price { get; set; }
        public IEnumerable<ItemOptionRequest> ItemOptions { get; set; } = Enumerable.Empty<ItemOptionRequest>();
    }

    public class ItemOptionRequest
    {
        public int ItemOptionId { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        public bool IncludedByDefault { get; set; }
        [Range(0, 1000)]
        public decimal AdditionalCost { get; set; }
    }
}
