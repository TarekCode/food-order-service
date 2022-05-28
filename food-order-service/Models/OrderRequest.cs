using System.ComponentModel.DataAnnotations;

namespace food_order_service.Models
{
    public class OrderRequest
    {
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Phone]
        [StringLength(24, MinimumLength = 10)]
        public string Phone { get; set; } = string.Empty;
        public ICollection<OrderItemRequest> OrderItems { get; set; } = new List<OrderItemRequest>();
    }

    public class OrderItemRequest
    {
        public int MenuItemId { get; set; }
        public ICollection<ItemModificationRequest> Modifications { get; set; } = new List<ItemModificationRequest>();
    }

    public class ItemModificationRequest
    {
        public int ItemOptionId { get; set; }
        [StringLength(10, MinimumLength = 3)]
        public string ChangeType { get; set; } = string.Empty;
    }
}
