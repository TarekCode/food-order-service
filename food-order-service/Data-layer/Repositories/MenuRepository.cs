﻿using food_order_service.Data_layer.DataModels;
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
                .Include(x => x.ItemOptions).FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<IEnumerable<MenuItem>> GetAll()
        {
            var item = await _foodServiceContext.MenuItems.AsNoTracking().Include(x => x.ItemOptions).ToListAsync();

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

        private void AddNew(MenuItem menuItem)
        {
            _foodServiceContext.MenuItems.Add(menuItem);
        }

        private void ReplaceExisting(MenuItem existingItem, MenuItem newItem)
        {
            //_foodServiceContext.Entry(item).CurrentValues.
        }
    }
}
