using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database.Entities
{
    public class HungryItemEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Item";
        public int Quantity { get; set; } = 1;
        public string Store { get; set; } ="Store";
        public bool Bought { get; set; } = false;

        public int HungryDayID { get; set; }

        public HungryDayEntity HungryDay { get; set; } 

        public void Update(HungryItemEntity entity)
        {
            this.Name = entity.Name;
            this.Quantity = entity.Quantity;
            this.Store = entity.Store;
            this.Bought = entity.Bought;
        }


        //public static void OnModelCreating(EntityTypeBuilder<HungryItemEntity> entity)
        //{
        //    entity
        //        .HasKey(x => x.Id);
        //    entity
        //        .HasOne(x => x.HungryDay)
        //        .WithMany(x => x.HungryItems)
        //        .HasForeignKey(x => x.HungryDayID);
        //}
    }
}
