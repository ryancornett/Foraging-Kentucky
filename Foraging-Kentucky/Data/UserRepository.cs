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

    public User Retrieve(string name)
    {
        return _context.Users.FirstOrDefault(user => user.Name == name);
    }

    public bool CheckIfExists(string name)
    {
        return _context.Users.Any(u => u.Name == name);
    }

    // Not needed for this entity
    public Task AddUserToList(User type, User user)
    {
        throw new NotImplementedException();
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
}