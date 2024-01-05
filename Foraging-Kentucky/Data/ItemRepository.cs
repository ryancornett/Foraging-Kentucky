using Foraging_Kentucky.Domain;
using Foraging_Kentucky.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Foraging_Kentucky.Data;

public class ItemRepository : IRepository<Item>
{
    private ForageContext _context;
    public ItemRepository()
    {
        _context = new ForageContext();
    }

    public Task<List<Item>> GetListAsync()
    {
        return _context.Items.AsNoTracking().ToListAsync();
    }

    public async Task Add(Item item)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            item.Log(method, $"{Logger.error} - {ex}");
        }
    }

    public async Task<Item> Retrieve(string name)
    {
        return await _context.Items.FirstOrDefaultAsync(item => item.Name == name);
    }

    public bool CheckIfExists(string name)
    {
        return _context.Items.Any(u => u.Name == name);
    }

    public async Task AddUserToItemList(Item item, User user)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            item.Users.Add(user);
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            _context.Entry(item).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            item.Log(method, $"{Logger.error} - {ex}");
        }
    }

    public async Task Delete(Item item)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            item.Log(method, $"{Logger.error} - {item.Name} - {ex}");
        }
    }

    public async Task Update(Item item)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            _context.Entry(item).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            item.Log(method, $"{Logger.error} - {item.Name} - {ex}");
        }
    }

    public async Task<List<Item>> RetrieveByProperty(string value)
    {
        return await _context.Items
            .Where(item => item.Type == value)
            .ToListAsync();
    }

    public async Task<List<Item>> RetrieveByRecentlyAdded()
    {
        return await _context.Items
            .AsNoTracking()
            .OrderByDescending(item => item.Created)
            .ToListAsync();
    }

    public async Task<List<Item>> RetrieveByFirstAdded()
    {
        return await _context.Items
            .AsNoTracking()
            .OrderBy(item => item.Created)
            .ToListAsync();
    }

    public async Task<List<Item>> RetrieveByAlphabeticalOrder()
    {
        return await _context.Items
            .AsNoTracking()
            .OrderBy(item => item.Name)
            .ToListAsync();
    }

    // NOT NEEDED FOR THIS ENTITY
    public Task AddItemToUserList(User user, Item item)
    {
        throw new NotImplementedException();
    }

    public Task AddUserToRecipeAddedBy(Recipe recipe, User user)
    {
        throw new NotImplementedException();
    }

    public Task RemoveItemFromUserList(User user, Item item)
    {
        throw new NotImplementedException();
    }
}
