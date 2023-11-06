using Foraging_Kentucky.Common;

namespace Foraging_Kentucky.Common;
public class User : IEntity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Item> Items { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;

    public User(string Name, string Email)
    {
        if (Validators.ValidateEmail(Email))
        {
            this.Email = Email;
        }
        else
        {
            this.Email = "genericeuser@genericuser.com";
        }
        this.Name = Name;
        Items = new List<Item>();
    }
}