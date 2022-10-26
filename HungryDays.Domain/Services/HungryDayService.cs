using HungryDays.Database.Entities;
using HungryDays.Database.Repositories;
using HungryDays.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Domain.Services
{
    public class HungryDayService
    {
        private Database.Repositories.HungryDayRepository _repository;
        public HungryDayService(Database.Repositories.HungryDayRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HungryDayEntity>> GetAll()
        {
            return await _repository.GetHungryDaysAsync();
        }

        public async Task<HungryDayEntity> Get(int id)
        {
            return await _repository.GetHungryDayAsync(id);
        }

        public async Task Update(HungryDayEntity entity)
        {
            var entityFromDb = await _repository.GetHungryDayAsync(entity.Id);

            if (entityFromDb == null)
                throw new Exception("Can't find entity to update");

            entityFromDb.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Reset(int id)
        {
            var entityFromDb = await _repository.GetHungryDayAsync(id);

            if (entityFromDb == null)
                throw new Exception("Can't find entity to reset");

            entityFromDb.Reset();

            await _repository.SaveChangesAsync();
        }

    }
}
