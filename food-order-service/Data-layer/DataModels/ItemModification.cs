using System.ComponentModel.DataAnnotations;

namespace food_order_service.Data_layer.DataModels
{
    public class ItemModification : DbObject
    {
        [Required]
        public ItemOption? ItemOption { get; set; }

        [MaxLength(10)]
        [MinLength(3)]
        public string ChangeType { get; set; } = string.Empty;

        public decimal ModificationCost
        {
            get
            {
                if (ChangeType == "Added" && ItemOption != null && !ItemOption.IncludedByDefault)
                {
                    return ItemOption.AdditionalCost;
                }

                return 0;
            }

            private set { }
        }
    }
}
