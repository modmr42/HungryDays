using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Domain.Models
{
    public class HungryItemDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid HungryDayId { get; set; }
        public string Name { get; set; } = "Item";
        public int Quantity { get; set; } = 0;
        public string Store { get; set; } = "Store";
        public bool Bought { get; set; } = false;
    }
}
