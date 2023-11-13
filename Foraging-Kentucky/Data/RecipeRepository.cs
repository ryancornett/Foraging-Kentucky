﻿using Foraging_Kentucky.Common;
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

    public void Add(Recipe recipe)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
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

    public void AddUserToList(Recipe type, User user)
    {
        throw new NotImplementedException();
    }
}