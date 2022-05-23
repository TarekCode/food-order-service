namespace food_order_service.Data_layer.DataModels
{
    public abstract class DbObject
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated
        {
            get
            {
                return DateTime.UtcNow;
            }

            private set { }
        }
    }
}
