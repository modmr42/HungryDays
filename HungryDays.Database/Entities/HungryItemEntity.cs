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
        public int Quantity { get; set; } = 0;
        public string Store { get; set; } ="Store";
        public bool Bought { get; set; } = false;
    }
}
