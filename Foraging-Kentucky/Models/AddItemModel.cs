namespace Foraging_Kentucky.Models
{
    public class AddItemModel
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string Description { get; set; }
        public bool IsEdibleRaw { get; set; }
    }
}
