namespace Foraging_Kentucky.Data
{
    public class Mushroom : Item
    {
        public Mushroom(string Name, List<string> MonthsAvailable, bool IsEdibleRaw, bool IsNative, bool IsInvasive) : base(Name, MonthsAvailable, IsEdibleRaw, IsNative, IsInvasive)
        {
        }

        public List<string> FruitingMonths { get; set; }
    }
}
