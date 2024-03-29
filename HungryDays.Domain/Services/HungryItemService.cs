﻿using HungryDays.Database.Entities;
using HungryDays.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Domain.Services
{
    public class HungryItemService
    {
        private HungryItemRepository _repository;
        public HungryItemService(HungryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HungryItemEntity>> GetAll()
        {
            var hungryItems = await _repository.GetHungryItemsAsync();
            hungryItems.OrderBy(x => x.Store);
            return hungryItems;
        }
        public async Task<IEnumerable<HungryItemEntity>> GetAll(string userId)
        {
            var hungryItems = await _repository.GetHungryItemsAsync();
            hungryItems.OrderBy(x => x.Store);
            return hungryItems;
        }

        public async Task<HungryItemEntity> Get(Guid id)
        {
            return await _repository.GetHungryItemAsync(id);
        }

        public async Task<HungryItemEntity> Get(Guid id, string userId)
        {
            return await _repository.GetHungryItemAsync(id, userId);
        }

        public async Task Add(HungryItemEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.AddHungryItem(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Update(HungryItemEntity entity)
        {
            var entityFromDb = await _repository.GetHungryItemAsync(entity.Id);

            if (entityFromDb == null)
                throw new Exception("Could not find item to update");

            entityFromDb.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entityFromDb = await _repository.GetHungryItemAsync(id);

            if (entityFromDb == null)
                throw new Exception("Could not find item to delete");

            _repository.DeleteHungryItem(entityFromDb);

            await _repository.SaveChangesAsync();

        }
    }
}
