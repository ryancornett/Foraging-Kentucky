namespace Foraging_Kentucky.Data
{
    public class Fruit : Item
    {
        public Fruit(string Name, List<string> MonthsAvailable, bool IsEdibleRaw, bool IsNative, bool IsInvasive) : base(Name, MonthsAvailable, IsEdibleRaw, IsNative, IsInvasive)
        {
        }
        public List<string> BlossomMonths { get; set; }
    }
}
