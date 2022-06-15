using System.ComponentModel.DataAnnotations;

namespace food_order_service.Data_layer.DataModels
{
    public class Order : DbObject
    {
        [MaxLength(50)]
        [MinLength(2)]
        public string CustomerName { get; set; } = string.Empty;
        [MaxLength(24)]
        [MinLength(7)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(12)]
        [MinLength(3)]
        public string OrderStatus { get; set; } = string.Empty;
        public ICollection<OrderItem>? OrderItems { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public decimal OrderTotal { get; set; }
    }

    public struct OrderStatusOptions
    {
        public static string New = "New";
        public static string Completed = "Completed";
        public static string Cancelled = "Cancelled";
    }
}
