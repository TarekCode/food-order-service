using System.ComponentModel.DataAnnotations;

namespace food_order_service.Data_layer.DataModels
{
    public class ItemOption : DbObject
    {
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;
        public bool IncludedByDefault { get; set; }        
        public decimal AdditionalCost { get; set; }
    }
}
