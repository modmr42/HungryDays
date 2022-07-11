using HungryDays.Domain.Models;
using Newtonsoft.Json;

namespace HungryDays.Domain.Repositories
{
    public class BaseHungryRepository
    {
        private string Path = "";
        private const string FileName = "Repository.json";

        public BaseHungryRepository()
        {
            this.Path = AppDomain.CurrentDomain.BaseDirectory + "/" + FileName;
            InitializeRepository();
        }
        private void InitializeRepository()
        {
            var isRepositoryEmpty = true;
            if (File.Exists(Path))
            {
                isRepositoryEmpty = String.IsNullOrEmpty(ReadAllToJson());
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
                            Diner = "Still not decided",
                            Items = new List<Item>()
                            {
                                new Item()
                                {
                                    Name ="Ingredient",
                                    Quantity = 1,
                                    Store = Enums.StoreToBuy.AlbertHeijn,
                                    Bought = true,
                                }
                            }
                        });
                }

                this.CreateJsonRepositoryFile();
                this.WriteAllHungryDays(hungryDays);
            }
        }
        protected string ReadAllToJson()
        {
            return File.ReadAllText(Path);
        }
        private void CreateJsonRepositoryFile()
        {
            File.WriteAllText(this.Path, "");
        }
        protected void WriteAllHungryDays(List<HungryDay> hungryDays)
        {
            var json = JsonConvert.SerializeObject(hungryDays);
            File.WriteAllText(Path, json);
        }

    }
}