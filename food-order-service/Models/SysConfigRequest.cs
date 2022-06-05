using System.ComponentModel.DataAnnotations;

namespace food_order_service.Models
{
    public class SysConfigRequest
    {
        [StringLength(50, MinimumLength = 2)]
        public string ConfigName { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 2)]
        public string ConfigValue { get; set; } = string.Empty;
    }
}
