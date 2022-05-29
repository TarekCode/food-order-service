using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace food_order_service.Data_layer.DataModels
{
    public class ItemModification : DbObject
    {
        [Required]
        [ForeignKey("ItemOption")]
        public int ItemOptionId { get; set; }

        [Required]
        public ItemOption? ItemOption { get; set; }

        [MaxLength(10)]
        [MinLength(3)]
        public string ChangeType { get; set; } = string.Empty;

        public decimal ModificationCost { get; set; }
    }
}
