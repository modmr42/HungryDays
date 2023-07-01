using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public static void OnModelCreating(EntityTypeBuilder<HungryUserEntity> entity)
        {
            entity
                .HasKey(x => x.Id);
            entity
                .HasMany(x => x.HungryDays)
                .WithOne(x => x.HungryUser)
                .HasForeignKey(x => x.HungryUserID);
        }
    }
}
