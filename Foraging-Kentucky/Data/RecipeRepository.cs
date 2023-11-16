using Foraging_Kentucky.Common;
using Foraging_Kentucky.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Foraging_Kentucky.Data;

public class RecipeRepository : IRepository<Recipe>
{
    private ForageContext _context;
    public RecipeRepository()
    {
        _context = new ForageContext();
    }

    public async Task<List<Recipe>> GetListAsync()
    {
        return await _context.Recipes.Include(r => r.WildFoodIncluded).Include(r => r.AddedBy).ToListAsync();
    }

    public async Task Add(Recipe recipe)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            recipe.Log(method, $"{Logger.error} - {ex}");
        }
    }

    public async Task<Recipe> Retrieve(string name)
    {
        return await _context.Recipes.FirstOrDefaultAsync(recipe => recipe.Name == name);
    }

    public bool CheckIfExists(string name)
    {
        return _context.Recipes.Any(u => u.Name == name);
    }

    public async Task AddUserToRecipeAddedBy(Recipe recipe, User user)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            recipe.AddedBy = user;
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
            _context.Entry(recipe).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            recipe.Log(method, $"{Logger.error} - {recipe.Name} - {ex}");
        }
    }

    public async Task Delete(Recipe recipe)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            recipe.Log(method, $"{Logger.error} - {recipe.Name} - {ex}");
        }
    }

    public async Task Update(Recipe recipe)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
            _context.Entry(recipe).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            recipe.Log(method, $"{Logger.error} - {recipe.Name} - {ex}");
        }
    }

    public async Task<List<Recipe>> RetrieveByProperty(string value)
    {
        return await _context.Recipes
            .Where(recipe => recipe.WildFoodIncluded.Name == value)
            .ToListAsync();
    }

    public Task<List<Recipe>> RetrieveByRecentlyAdded()
    {
        throw new NotImplementedException();
    }

    public Task<List<Recipe>> RetrieveByFirstAdded()
    {
        throw new NotImplementedException();
    }

    public Task<List<Recipe>> RetrieveByAlphabeticalOrder()
    {
        throw new NotImplementedException();
    }

    public Task AddUserToItemList(Item item, User user)
    {
        throw new NotImplementedException();
    }

    public Task AddItemToUserList(User user, Item item)
    {
        throw new NotImplementedException();
    }
}