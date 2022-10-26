using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Domain.Models
{
    public class HungryDayDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Diner { get; set; }

        public List<HungryItemDto> HungryItems { get; set; }
    }
}
