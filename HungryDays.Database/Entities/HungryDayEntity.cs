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
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public string Diner { get; set; }
        public ICollection<HungryItemEntity> HungryItems { get; set; }

        public void Update(HungryDayEntity entity)
        {
            this.Diner = entity.Diner;
            this.Day = entity.Day;
            this.HungryItems = entity.HungryItems;
        }

        public void Reset()
        {
            this.Diner = "Still not decided";
            this.HungryItems.Clear();

        }

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
