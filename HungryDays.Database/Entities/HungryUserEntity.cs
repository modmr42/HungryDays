using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database.Entities
{
    public class HungryUserEntity : IdentityUser
    {
        ICollection<HungryDayEntity> HungryDays { get; set; } = new List<HungryDayEntity>();
    }
}
