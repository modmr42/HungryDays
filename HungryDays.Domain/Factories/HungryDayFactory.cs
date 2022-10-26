using HungryDays.Database.Entities;
using HungryDays.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Domain.Factories
{
    public class HungryDayFactory
    {
        public HungryDayDto ToDto(HungryDayEntity entity)
        {
            return new HungryDayDto
            {
                Id = entity.Id,
                Day = entity.Day,
                Diner = entity.Diner,
                HungryItems = entity.HungryItems.Select(x => new HungryItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Bought = x.Bought,
                    Store = x.Store,
                    HungryDayId = x.HungryDayID
                }).ToList()
            };
        }
        
        public HungryDayEntity ToEntity(HungryDayDto dto)
        {
            return new HungryDayEntity
            {
                Id =dto.Id,
                Day = dto.Day,
                Diner = dto.Diner,
                HungryItems = dto.HungryItems.Select(x => new HungryItemEntity
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Bought = x.Bought,
                    Store = x.Store,
                    HungryDayID = x.HungryDayId
                }).ToList()
            };
        }
    }
}
