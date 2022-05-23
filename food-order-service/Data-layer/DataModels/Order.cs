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
        public IEnumerable<OrderItem> OrderItems { get; set; } = Enumerable.Empty<OrderItem>();
        public decimal OrderTotal
        {
            get
            {
                return OrderItems.Sum(x => x.Cost);
            }

            private set { }
        }
    }
}
