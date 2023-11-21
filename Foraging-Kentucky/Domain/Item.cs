namespace Foraging_Kentucky.Domain;

// The Item object follows the Open-Closed principle.
// It is extended by methods in the Logger class, but closed for modification.
public class Item
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsEdibleRaw { get; set; }
    public List<User> Users { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;
    public string ImagePath { get; set; }
    public Item(string Name)
    {
        this.Name = Name;
        Users = new List<User>();
    }
}
