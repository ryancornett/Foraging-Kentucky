using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foraging_Kentucky.Data
{
    public static class Constants
    {
        public static List<string> Regions = new List<string> {
            "Jackson Purchase", "Mississippi Plateau", "Western Coal Fields", "Bluegrass", "Cumberland Plateau" };
        public static List<string> Months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public enum Frequency { Abundant, Common, Infrequent, Rare }
        public enum PlantType { Tree, Bush, Vine, Annual, Fungus }
        public enum HullType { Fleshy, Solid, Involucre, None }
    }
}
