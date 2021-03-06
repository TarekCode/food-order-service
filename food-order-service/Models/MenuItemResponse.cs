namespace food_order_service.Models
{
    public record MenuItemResponse
    {
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public short MinutesToPrepare { get; init; }
        public IEnumerable<ItemOptionResponse> ItemOptions { get; init; } = Enumerable.Empty<ItemOptionResponse>();
    }

    public record ItemOptionResponse
    {
        public string Name { get; init; } = string.Empty;
        public bool IncludedByDefault { get; init; }
        public decimal AdditionalCost { get; init; }
    }
}
