using System.ComponentModel.DataAnnotations;

namespace food_order_service.Data_layer.DataModels
{
    public class MenuItem : DbObject
    {
        [MaxLength(128)]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<ItemOption>? ItemOptions { get; set; }
    }
}
