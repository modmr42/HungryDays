using Hungry.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Shared.Repositories
{
    public class HungryRepository
    {
        private string Path = "";
        private const string FileName = "Repository.json";

        public HungryRepository()
        {
            this.Path = AppDomain.CurrentDomain.BaseDirectory + "/" + FileName;
            InitializeRepository();
        }

        public void InitializeRepository()
        {
            var isRepositoryEmpty = true;
            if (File.Exists(Path))
            {
                isRepositoryEmpty = String.IsNullOrEmpty(ReadAllJson());
            }

            if (isRepositoryEmpty)
            {
                string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                var hungryDays = new List<HungryDay>();
                for (int i = 0; i < days.Length; i++)
                {
                    hungryDays.Add(
                        new HungryDay
                        {
                            Id = i,
                            Name = days[i],
                            Diner = "Indo food",
                            Items = new List<Item>()
                            {
                                new Item(),
                                new Item(),
                                new Item()

                            }
                        });
                }

                this.CreateJsonRepositoryFile();
                this.WriteAllHungryDays(hungryDays);
            }
        }

        public HungryDay GetHungryDay(int id)
        {
            var hungryDays = GetAllHungryDays();
            var hungryDay = hungryDays.FirstOrDefault(x => x.Id == id);
            return hungryDay;
        }

        public void ResetHungryDay(int id)
        {
            var hungryDays = GetAllHungryDays();
            var hungryDay = hungryDays.FirstOrDefault(x => x.Id == id);
            hungryDay.Diner = "";
            hungryDay.Items = new List<Item>();

            hungryDays[id] = hungryDay;

            WriteAllHungryDays(hungryDays);
        }


        public string ReadAllJson()
        {
            return File.ReadAllText(Path);
        }

        public void WriteAllHungryDays(List<HungryDay> hungryDays)
        {
            var json = JsonConvert.SerializeObject(hungryDays);
            File.WriteAllText(Path, json);
        }

        public void CreateJsonRepositoryFile()
        {
            File.WriteAllText(this.Path, "");
        }
        public List<HungryDay> GetAllHungryDays()
        {
            var json = this.ReadAllJson();
            var hungryDays = JsonConvert.DeserializeObject<List<HungryDay>>(json);
            return hungryDays;
        }
    }
}
