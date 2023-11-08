namespace Foraging_Kentucky.Domain;
public class Item : IEntity
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string Name { get; set; }

    // Regions found, frequency, plant type, hull type, months available, native or not, invasive or not, etc.
    public string Description { get; set; }
    public bool IsEdibleRaw { get; set; }
    public List<User> Users { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;
    public Item(string Name)
    {
        this.Name = Name;
        Users = new List<User>();
    }
}
