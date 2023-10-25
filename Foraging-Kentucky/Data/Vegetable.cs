namespace Foraging_Kentucky.Data
{
    public class Vegetable : Item
    {
        public Vegetable(string Name, List<string> MonthsAvailable, bool IsEdibleRaw, bool IsNative, bool IsInvasive) : base(Name, MonthsAvailable, IsEdibleRaw, IsNative, IsInvasive)
        {
        }

        public List<string> FlowerMonths { get; set; }
    }
}
