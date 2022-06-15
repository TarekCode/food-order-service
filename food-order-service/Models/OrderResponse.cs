namespace food_order_service.Models
{
    public record OrderResponse
    {
        public int OrderId { get; init; }
        public string CustomerName { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public decimal OrderTotal { get; init; }
        public IEnumerable<OrderItemResponse> OrderItems { get; init; } = Enumerable.Empty<OrderItemResponse>();
    }

    public record OrderItemResponse
    {
        public string MenuItemName { get; init; } = string.Empty;
        public decimal BasePrice { get; init; }
        public IEnumerable<ItemModificationResponse> Modifications { get; init; } = Enumerable.Empty<ItemModificationResponse>();
    }

    public record ItemModificationResponse
    {
        public string ItemName { get; init; } = string.Empty;
        public string ChangeType { get; init; } = string.Empty;
        public decimal ModificationCost { get; init; }
    }
}
