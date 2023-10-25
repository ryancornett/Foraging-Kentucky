namespace Foraging_Kentucky.Data
{
    public class Nut : Item
    {
        public Nut(string Name, List<string> MonthsAvailable, bool IsEdibleRaw, bool IsNative, bool IsInvasive) : base(Name, MonthsAvailable, IsEdibleRaw, IsNative, IsInvasive)
        {
        }

        public Constants.HullType HullType { get; set; }
    }
}
