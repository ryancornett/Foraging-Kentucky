using Foraging_Kentucky.Common;

namespace Foraging_Kentucky.Data;
public static class Seed
{
    public static List<User> CreateUsers()
    {
        var list = new List<User>
        {
            new User("Dave", "dave@wendys.com"),
            new User("Dread Pirate Roberts", "pirateguy08@asyouwish.net"),
            new User("Aragorn Stryder", "king@gondor.com"),
            new User("Eowyn", "rohanrules@horselords.gov"),
            new User("Olivia Dunham", "olive@fringe.fbi.gov")
        };
        return list;
    }
    public static List<Item> CreateItems()
    {
        var userList = CreateUsers();
        var list = new List<Item>();
        var one = new Item("Black Walnut")
        {
            Type = ItemOptions.ItemTypes[2],
            Description = string.Empty,
            IsEdibleRaw = true
        };
        one.Users.Add(userList[0]); // Adds Dave to Black Walnut; use indexing to vary users added
        list.Add(one);
        return list;
    }

    public static List<Recipe> CreateRecipes()
    {
        var userList = CreateUsers();
        var itemList = CreateItems();
        var list = new List<Recipe>();
        var bananaNutBread = new Recipe() { Name = "Banana Nut Bread", WildFoodIncluded = itemList[0], Ingredients = "Lorem Ipsum", Instructions = "Put it in your face-mouth.", AddedBy = userList[0] }; // adding by list doesn't work!
        list.Add(bananaNutBread);
        return list;
    }

    public static void SeedDatabase()
    {
        var items = CreateItems();
        var users = CreateUsers();
        var recipes = CreateRecipes();
        var context = new ForageContext();

        foreach (var item in items)
        { context.Items.Add(item); }

        foreach (var user in users)
        { context.Users.Add(user); }

        foreach (var recipe in recipes)
        { context.Recipes.Add(recipe); }

        context.SaveChanges();
        Console.WriteLine("Seed method called.");
    }
}
