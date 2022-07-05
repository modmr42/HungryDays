using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Shared.Models
{
    public class HungryDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diner { get; set; }

        public List<Item> Items { get; set; }
    }
}
