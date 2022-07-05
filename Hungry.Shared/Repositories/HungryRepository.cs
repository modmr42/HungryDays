using Hungry.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Shared.Repositories
{
    public class HungryRepository : BaseHungryRepository
    {
        public HungryDay GetHungryDay(int id)
        {
            var hungryDays = GetHungryDays();
            var hungryDay = hungryDays.FirstOrDefault(x => x.Id == id);
            return hungryDay;
        }

        public void ResetHungryDay(int id)
        {
            var hungryDays = GetHungryDays();
            var hungryDay = hungryDays.FirstOrDefault(x => x.Id == id);
            hungryDay.Diner = "";
            hungryDay.Items.Clear();

            hungryDays[id] = hungryDay;

            WriteAllHungryDays(hungryDays);
        }

        public void ResetHungryDays()
        {
            var hungryDays = GetHungryDays();
            hungryDays.ForEach(hungryDay =>
            {
                hungryDay.Diner = "";
                hungryDay.Items.Clear();
            });
        }

        public void EditHungryDay(HungryDay dto)
        {
            var hungryDays = GetHungryDays();
            hungryDays[dto.Id] = dto;
            WriteAllHungryDays(hungryDays);
        }


        public List<HungryDay> GetHungryDays()
        {
            var json = this.ReadAllToJson();
            var hungryDays = JsonConvert.DeserializeObject<List<HungryDay>>(json);
            return hungryDays;
        }
    }
}
