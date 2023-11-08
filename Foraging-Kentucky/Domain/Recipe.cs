namespace Foraging_Kentucky.Domain;
public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Item WildFoodIncluded { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    public User AddedBy { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;
}
