using System.ComponentModel.DataAnnotations;

namespace food_order_service.Data_layer.DataModels
{
    public class ConfigOption : DbObject
    {
        [MaxLength(50)]
        [MinLength(2)]
        public string Key { get; set; } = string.Empty;
        [MaxLength(100)]
        [MinLength(2)]
        public string Value { get; set; } = string.Empty;
    }
}
