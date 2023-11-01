using Foraging_Kentucky.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foraging_Kentucky.Data;
public partial class DbMethods
{
    public List<Recipe> GetRecipesByUser(User user)
    {
        using var context = new ForageContext();
        return context.Recipes.Include(recipes => recipes.AddedBy == user).ToList();
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

    // The issue here is getting into the Users List<User>. We need the item.user, not item.Users
    /*public List<(string ItemName, string RecipeName, string UserName)> GetItemsAndRecipesWithUser()
    {
        using var context = new ForageContext();
        var query = from item in context.Items
                    join recipe in context.Recipes on item.Users equals recipe.AddedBy
                    join user in context.Users on item.UserId equals user.Id
                    select new
                    {
                        ItemName = item.Name,
                        RecipeName = recipe.Name,
                        UserName = user.UserName
                    };

        return query.ToList()
            .Select(result => (result.ItemName, result.RecipeName, result.UserName))
            .ToList();
    }*/

    public static void AddItemWithUser(string userName)
    {
        var context = new ForageContext();
        var nameFromDb = context.Users.Where(n => n.Name == userName).FirstOrDefault();
        if (nameFromDb == null) { nameFromDb = new User(userName, "default@default.com"); }
        var item = new Item("Autumn Olive") { Type = ItemOptions.ItemTypes[0], Description = "Invasive plant with small, slightly astringent drupes that are high in lycopene.", IsEdibleRaw = true };
        item.Users.Add(nameFromDb);
        item.Users.Add(new User("Testing Parameter", "test@testthis.net"));
        context.Items.Add(item);
        context.SaveChanges();
    }

    public static void AddItemWithUser(string userName, string email)
    {
        var context = new ForageContext();
        var nameFromDb = context.Users.Where(n => n.Name == userName).FirstOrDefault();
        if (nameFromDb == null) { nameFromDb = new User(userName, email); }
        var item = new Item("Autumn Olive") { Type = ItemOptions.ItemTypes[0], Description = "Invasive plant with small, slightly astringent drupes that are high in lycopene.", IsEdibleRaw = true };
        item.Users.Add(nameFromDb);
        item.Users.Add(new User("Testing Parameter", "test@testthis.net"));
        context.Items.Add(item);
        context.SaveChanges();
    }
}
