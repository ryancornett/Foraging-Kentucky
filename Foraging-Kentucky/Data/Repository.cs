using Foraging_Kentucky.Common;
using Microsoft.EntityFrameworkCore;

namespace Foraging_Kentucky.Data;
public class Repository
{
    private ForageContext _context;
    public Repository(ForageContext context)
    {
        _context = context;
    }

    public List<Recipe> GetRecipesByUser(User user)
    {
        
        return _context.Recipes.Include(recipes => recipes.AddedBy == user).ToList();
    }

    public List<string> GetEntityNames(List<IEntity> entities)
    {
        var list = new List<string>();
        foreach (var entity in entities)
        {
            list.Add(entity.Name);
        }
        return list;
    }

    public void AddItemWithUser(string userName)
    {
        var nameFromDb = _context.Users.Where(n => n.Name == userName).FirstOrDefault();
        if (nameFromDb == null) { nameFromDb = new User(userName, "default@default.com"); }
        var item = new Item("Autumn Olive") { Type = ItemOptions.ItemTypes[0], Description = "Invasive plant with small, slightly astringent drupes that are high in lycopene.", IsEdibleRaw = true };
        item.Users.Add(nameFromDb);
        item.Users.Add(new User("Testing Parameter", "test@testthis.net"));
        _context.Items.Add(item);
        _context.SaveChanges();
    }

    public void AddItemWithUser(string userName, string email)
    {
        var nameFromDb = _context.Users.Where(n => n.Name == userName).FirstOrDefault();
        if (nameFromDb == null) { nameFromDb = new User(userName, email); }
        var item = new Item("Autumn Olive") { Type = ItemOptions.ItemTypes[0], Description = "Invasive plant with small, slightly astringent drupes that are high in lycopene.", IsEdibleRaw = true };
        item.Users.Add(nameFromDb);
        item.Users.Add(new User("Testing Parameter", "test@testthis.net"));
        _context.Items.Add(item);
        _context.SaveChanges();
    }

    public void RetrieveAndUpdateItemType(string itemName, string type)
    {
        var item = _context.Items.FirstOrDefault(n => n.Name == itemName);
        if (item == null) { return; }
        else
        {
            item.Type = type;
            item.Updated = DateTime.Now;
            _context.SaveChanges();
        }
    }

    public void RetrieveAndUpdateItemName(string oldItemName, string newItemName)
    {
        var item = _context.Items.FirstOrDefault(n => n.Name == oldItemName);
        if (item == null) { return; }
        else
        {
            item.Name = newItemName;
            item.Updated = DateTime.Now;
            _context.SaveChanges();
        }
    }

    public void RetrieveAndUpdateItemDescription(string itemName, string description)
    {
        var item = _context.Items.FirstOrDefault(n => n.Name == itemName);
        if (item == null) { return; }
        else
        {
            item.Description = description;
            item.Updated = DateTime.Now;
            _context.SaveChanges();
        }
    }

    public void RetrieveAndUpdateItemIsEdibleRaw(string itemName, string isEdibleRaw)
    {
        var item = _context.Items.FirstOrDefault(n => n.Name == itemName);
        if (item == null) { return; }
        else
        {
            bool isEdible = isEdibleRaw.ToLower() == "true" ? true : false;
            item.IsEdibleRaw = isEdible;
            item.Updated = DateTime.Now;
            _context.SaveChanges();
        }
    }

    public void RetrieveAndUpdateUserName(string oldUsername, string newUsername)
    {
        var user = _context.Users.FirstOrDefault(n => n.Name == oldUsername);
        user.Name = newUsername;
        user.Updated = DateTime.Now;
        _context.SaveChanges();
    }

    public void RetrieveAndUpdateUserEmail(string username, string newEmail)
    {
        
        var user = _context.Users.FirstOrDefault(n => n.Name == username);
        if (!Validators.ValidateEmail(newEmail)) { return; }
        else
        {
            user.Email = newEmail;
            user.Updated = DateTime.Now;
            _context.SaveChanges();
        }
    }
}