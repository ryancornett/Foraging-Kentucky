namespace Foraging_Kentucky.Data
{
    public abstract class Item
    {
        public int Id { get; private set; }
        private string _name;
        private List<string> _monthsAvailable { get; }
        private bool _isEdibleRaw { get; }
        private bool _isNative { get; }
        private bool _isInvasive { get; }

        public Item(string Name, List<string> MonthsAvailable, bool IsEdibleRaw, bool IsNative, bool IsInvasive)
        {
            _name = Name;
            _monthsAvailable = MonthsAvailable;
            _isEdibleRaw = IsEdibleRaw;
            _isNative = IsNative;
            _isInvasive = IsInvasive;
        }
    }
}
