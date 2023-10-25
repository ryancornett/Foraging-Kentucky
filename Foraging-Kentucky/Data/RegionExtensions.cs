using System.Reflection;

namespace Foraging_Kentucky.Data
{
    public static class RegionExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo.GetCustomAttribute(typeof(RegionDisplayNameAttribute)) is RegionDisplayNameAttribute attribute)
            {
                return attribute.DisplayName;
            }

            return value.ToString(); // Use the enum value if no display name is specified.
        }
    }
}
