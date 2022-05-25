using food_order_service.Data_layer.DataModels;

namespace food_order_service.Data_layer.Repositories
{
    public interface IMenuRepository
    {
        Task<MenuItem?> GetById(int id);
        Task<IEnumerable<MenuItem>> GetAll();
        Task SaveMenuItem(MenuItem menuItem);
        Task<bool> DeleteMenuItem(int id);
    }
}
