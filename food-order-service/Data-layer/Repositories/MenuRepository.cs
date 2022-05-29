using food_order_service.Data_layer.DataModels;
using Microsoft.EntityFrameworkCore;

namespace food_order_service.Data_layer.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly FoodServiceContext _foodServiceContext;

        public MenuRepository(FoodServiceContext foodServiceContext)
        {
            _foodServiceContext = foodServiceContext;
        }

        public async Task<MenuItem?> GetById(int id)
        {
            MenuItem? item = await _foodServiceContext.MenuItems.AsNoTracking()
                .Include(x => x.ItemOptions).FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

            return item;
        }

        public async Task<IEnumerable<MenuItem>> GetAll()
        {
            var item = await _foodServiceContext.MenuItems.AsNoTracking()
                .Where(x => !x.Deleted)
                .Include(x => x.ItemOptions).ToListAsync();

            return item;
        }

        public async Task SaveMenuItem(MenuItem menuItem)
        {
            MenuItem? item = await _foodServiceContext.MenuItems.Include(x => x.ItemOptions).FirstOrDefaultAsync(x => x.Id == menuItem.Id);

            if (item == null)
            {
                AddNew(menuItem);
            }
            else
            {
                ReplaceExisting(item, menuItem);
            }

            await _foodServiceContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteMenuItem(int id)
        {
            MenuItem? itemToDelete = await _foodServiceContext.MenuItems.Include(x => x.ItemOptions).FirstOrDefaultAsync(x => x.Id == id);
            if (itemToDelete == null) { return false; }

            itemToDelete.Deleted = true;

            await _foodServiceContext.SaveChangesAsync();

            return true;
        }

        private void AddNew(MenuItem menuItem)
        {
            _foodServiceContext.MenuItems.Add(menuItem);
        }

        private void ReplaceExisting(MenuItem existingItem, MenuItem newItem)
        {
            if (existingItem.ItemOptions == null) { existingItem.ItemOptions = new List<ItemOption>(); }
            if (newItem.ItemOptions == null) { newItem.ItemOptions = new List<ItemOption>(); }

            //update existing items and remove missing items
            foreach (var itemOption in existingItem.ItemOptions)
            {
                var match = newItem.ItemOptions.FirstOrDefault(x => x.Id == itemOption.Id);

                if (match != null)
                {
                    match.DateCreated = itemOption.DateCreated;
                    _foodServiceContext.Entry(itemOption).CurrentValues.SetValues(match);
                }
                else
                {
                    _foodServiceContext.ItemOptions.Remove(itemOption);
                }
            }

            //add new items
            foreach (var itemOption in newItem.ItemOptions)
            {
                if (itemOption.Id == 0)
                {
                    existingItem.ItemOptions.Add(itemOption);
                }
            }

            newItem.DateCreated = existingItem.DateCreated;
            _foodServiceContext.Entry(existingItem).CurrentValues.SetValues(newItem);
        }
    }
}
