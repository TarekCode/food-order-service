using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace food_order_service.Data_layer.DataModels
{
    public class OrderItem : DbObject
    {
        [Required]
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        
        [Required]
        public MenuItem? MenuItem { get; set; }
        
        public ICollection<ItemModification>? ItemModifications { get; set; }

        public decimal Cost { get; set; }
    }
}
