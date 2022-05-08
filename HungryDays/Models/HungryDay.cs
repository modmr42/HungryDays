namespace HungryDays.Models
{
    public class HungryDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diner { get; set; }

        public List<Item> Items { get; set; }
    }
}
