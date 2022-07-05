using Hungry.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Shared.Models
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public int Quantity { get; set; } = 0;
        public StoreToBuy Store { get; set; } = StoreToBuy.None;
        public bool Bought { get; set; } = false;
    }
}
