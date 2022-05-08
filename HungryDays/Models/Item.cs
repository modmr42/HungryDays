namespace HungryDays.Models
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Item";
        public string Store { get; set; } = "Ah";
        public bool Bought { get; set; } = false;
    }
}