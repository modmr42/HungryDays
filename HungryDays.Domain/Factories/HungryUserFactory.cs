using HungryDays.Database.Entities;
using HungryDays.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Domain.Factories
{
    public static class HungryUserFactory
    {
        public static HungryUserEntity ToEntity(HungryUserDto dto) 
        {
            return new HungryUserEntity
            {
                UserName = dto.UserName,
                Email = dto.Email,
            };
        }
        public static HungryUserDto ToDto() { throw new NotImplementedException(); }
    }
}
