namespace HungryDays.Models
{
    public class HungryWeek
    {
        public Guid Id { get; set; }
        public List<HungryDay> AllDays { get; set; }
        public List<Item> AllItems { get; set; }
    }
}
