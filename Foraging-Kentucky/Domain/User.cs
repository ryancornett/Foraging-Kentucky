using Foraging_Kentucky.Common;
using System.ComponentModel.DataAnnotations;

namespace Foraging_Kentucky.Domain;
public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Item>? Items { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;

    public User(string Name, string Email)
    {
        this.Name = Name;
        this.Email = Email;
        Items = new List<Item>();
    }
}