using System.ComponentModel.DataAnnotations;

namespace food_order_service.Data_layer.DataModels
{
    public class OrderItem : DbObject
    {
        [Required]
        public MenuItem? MenuItem { get; set; }
        public ICollection<ItemModification>? ItemModifications { get; set; }

        public decimal Cost
        {
            get
            {
                if (MenuItem != null && ItemModifications != null)
                {
                    return ItemModifications.Sum(x => x.ModificationCost) + MenuItem.Price;
                }

                return 0;
            }

            private set { }
        }
    }
}
