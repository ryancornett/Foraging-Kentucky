using Foraging_Kentucky.Common;
using Foraging_Kentucky.Domain;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Foraging_Kentucky.Data;
public class Repository
{
    private ForageContext _context;
    public Repository()
    {
        _context = new ForageContext();
    }

    public List<Recipe> GetRecipesByUser(User user)
    {
        
        return _context.Recipes.Include(recipes => recipes.AddedBy == user).ToList();
    }

    public void AddItemWithUser(string userName)
    {
        var nameFromDb = _context.Users.Where(n => n.Name == userName).FirstOrDefault();
        if (nameFromDb == null) { nameFromDb = new User(userName, "default@default.com"); }
        var item = new Item("Autumn Olive") { Type = ItemOptions.ItemTypes[0], Description = @"Invasive plant with small, slightly astringent drupes that are high in lycopene.", IsEdibleRaw = true };
        item.Users.Add(nameFromDb);
        item.Users.Add(new User("Testing Parameter", "test@testthis.net"));
        _context.Items.Add(item);
        _context.SaveChanges();
    }

    public void AddItemWithUser(string userName, string email)
    {
        var nameFromDb = _context.Users.Where(n => n.Name == userName).FirstOrDefault();
        if (nameFromDb == null) { nameFromDb = new User(userName, email); }
        var item = new Item("Autumn Olive") { Type = ItemOptions.ItemTypes[0], Description = @"Invasive plant with small, slightly astringent drupes that are high in lycopene.", IsEdibleRaw = true };
        item.Users.Add(nameFromDb);
        item.Users.Add(new User("Testing Parameter", "test@testthis.net"));
        _context.Items.Add(item);
        _context.SaveChanges();
    }

    #region Item Methods
    
    
    public void UpdateExistingItem(Item item)
    {
        item.Updated = DateTime.Now;
        _context.Items.Update(item);
        _context.SaveChanges();
    }

    public void RetrieveAndUpdateItemType(string itemName, string type)
    {
        var item = _context.Items.FirstOrDefault(n => n.Name == itemName);
        if (item == null) { return; }
        else
        {
            item.Type = type;
            UpdateExistingItem(item);
        }
    }

    public void RetrieveAndUpdateItemName(string oldItemName, string newItemName)
    {
        var item = _context.Items.FirstOrDefault(n => n.Name == oldItemName);
        if (item == null) { return; }
        else
        {
            item.Name = newItemName;
            UpdateExistingItem(item);
        }
    }

    public void RetrieveAndUpdateItemDescription(string itemName, string description)
    {
        var item = _context.Items.FirstOrDefault(n => n.Name == itemName);
        if (item == null) { return; }
        else
        {
            item.Description = description;
            UpdateExistingItem(item);
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
            UpdateExistingItem(item);
        }
    }
    #endregion

    #region User Methods
    public void UpdateExistingUser(User user)
    {
        user.Updated = DateTime.Now;
        _context.Users.Update(user);
        _context.SaveChanges();
    }
    public void RetrieveAndUpdateUserName(string oldUsername, string newUsername)
    {
        var user = _context.Users.FirstOrDefault(n => n.Name == oldUsername);
        user.Name = newUsername;
        UpdateExistingUser(user);
    }

    public void RetrieveAndUpdateUserEmail(string username, string newEmail)
    {
        
        var user = _context.Users.FirstOrDefault(n => n.Name == username);
        if (!Validators.ValidateEmail(newEmail)) { return; }
        else
        {
            user.Email = newEmail;
            UpdateExistingUser(user);
        }
    }

    public void DeleteUser(string username)
    {
        var user = _context.Users.FirstOrDefault(n => n.Name == username);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    #endregion

    #region Recipe Methods
    public void UpdateExistingRecipe(Recipe recipe)
    {
        recipe.Updated = DateTime.Now;
        _context.Recipes.Update(recipe);
        _context.SaveChanges();
    }
    public void RetrieveAndUpdateRecipeName(string oldRecipeName, string newRecipeName)
    {
        var recipe = _context.Recipes.FirstOrDefault(n => n.Name == oldRecipeName);
        if (recipe == null) { return; }
        else
        {
            recipe.Name = newRecipeName;
            UpdateExistingRecipe(recipe);
        }
    }

    public void RetrieveAndUpdateRecipeInstructions(string recipeName, string instructions)
    {
        var recipe = _context.Recipes.FirstOrDefault(n => n.Name == recipeName);
        if (recipe == null) { return; }
        else
        {
            recipe.Instructions = instructions;
            UpdateExistingRecipe(recipe);
        }
    }

    public void RetrieveAndUpdateRecipeIngredients(string recipeName, string ingredients)
    {
        var recipe = _context.Recipes.FirstOrDefault(n => n.Name == recipeName);
        if (recipe == null) { return; }
        else
        {
            recipe.Ingredients = ingredients;
            UpdateExistingRecipe(recipe);
        }
    }
    #endregion
}
