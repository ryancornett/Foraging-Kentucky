namespace Foraging_Kentucky.Data
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class RegionDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; }

        public RegionDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
