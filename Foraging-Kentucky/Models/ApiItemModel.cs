using Foraging_Kentucky.Domain;

namespace Foraging_Kentucky.Models
{
    public class ApiItemModel
    {
        public string? Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEdibleRaw { get; set; }
        public string ImagePath { get; set; }
    }
}
