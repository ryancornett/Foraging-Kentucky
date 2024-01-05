using Foraging_Kentucky.Common;
using Foraging_Kentucky.Domain;
using Foraging_Kentucky.Pages;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Foraging_Kentucky.Data;

public class UserRepository : IRepository<User>
{
    private ForageContext _context;
    public UserRepository()
    {
        _context = new ForageContext();
    }

    public Task<List<User>> GetListAsync()
    {
        return _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task Add(User user)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            user.Log(method, $"{Logger.error} - {user.Name} - {ex}");
        }
    }

    public async Task<User> Retrieve(string name)
    {
        return await _context.Users.Include(u => u.Items).FirstOrDefaultAsync(user => user.Name == name);
    }

    public bool CheckIfExists(string name)
    {
        return _context.Users.Any(u => u.Name == name);
    }

    public async Task Delete(User user)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            user.Log(method, $"{Logger.error} - {user.Name} - {ex}");
        }
    }

    public async Task Update(User user)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            user.Log(method, $"{Logger.error} - {user.Name} - {ex}");
        }
    }

    public async Task AddItemToUserList(User user, Item item)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            user.Items.Add(item);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            user.Log(method, $"{Logger.error} - {user.Name} - {ex}");
        }

    }

    public async Task RemoveItemFromUserList(User user, Item item)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            user.Items.Remove(item);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            user.Log(method, $"{Logger.error} - {user.Name} - {ex}");
        }

    }

    // Not needed for this entity
    public Task<List<User>> RetrieveByProperty(string value)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> RetrieveByRecentlyAdded()
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> RetrieveByFirstAdded()
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> RetrieveByAlphabeticalOrder()
    {
        throw new NotImplementedException();
    }

    // NOT NEEDED FOR THIS ENTITY
    public Task AddUserToItemList(Item item, User user)
    {
        throw new NotImplementedException();
    }

    public Task AddUserToRecipeAddedBy(Recipe recipe, User user)
    {
        throw new NotImplementedException();
    }
}