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

    public Recipe Retrieve(string name)
    {
        return _context.Recipes.FirstOrDefault(recipe => recipe.Name == name);
    }

    public bool CheckIfExists(string name)
    {
        return _context.Recipes.Any(u => u.Name == name);
    }

    public async Task AddUserToList(Recipe recipe, User user)
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
}