using HungryDays.Database.Entities;
using HungryDays.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Domain.Factories
{
    public class HungryItemFactory
    {
        public HungryItemEntity ToEntity(HungryItemDto dto)
        {
            return new HungryItemEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                HungryDayID = dto.HungryDayId,
                Bought = dto.Bought,
                Quantity = dto.Quantity,
                Store = dto.Store,
            };
        }

        public HungryItemDto ToDto(HungryItemEntity entity)
        {
            return new HungryItemDto
            {
                Id = entity.Id,
                Name = entity.Name,
                HungryDayId = entity.HungryDayID,
                Bought = entity.Bought,
                Quantity = entity.Quantity,
                Store = entity.Store,
            };
        }
    }
}
