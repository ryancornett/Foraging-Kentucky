namespace Foraging_Kentucky.Models
{
    public class ItemModel
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string Description { get; set; }
        public bool IsEdibleRaw { get; set; }
        public string ImagePath { get; set; }
    }
}
