using HungryDays.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database.Repositories
{
    public class HungryItemRepository
    {
        private HungryDaysDbContext _dbContext;
        public HungryItemRepository(HungryDaysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<HungryItemEntity>> GetHungryItemsAsync()
        {
            return await _dbContext.HungryItems
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<HungryItemEntity> GetHungryItemAsync(Guid id)
        {
            return await _dbContext.HungryItems
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void DeleteHungryItem(HungryItemEntity entity)
        {
            _dbContext.HungryItems.Remove(entity);
        }

        public async Task SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}
