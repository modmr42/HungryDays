using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database.Entities
{
    public class HungryDayEntity
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Diner { get; set; }
        public ICollection<HungryItemEntity> HungryItems { get; set; }

        public static void OnModelCreating(EntityTypeBuilder<HungryDayEntity> entity)
        {
            entity
                .HasKey(x => x.Id);
            entity
                .HasMany(x => x.HungryItems)
                .WithOne(x => x.HungryDay)
                .HasForeignKey(x => x.HungryDayID);
        }

    }
}
