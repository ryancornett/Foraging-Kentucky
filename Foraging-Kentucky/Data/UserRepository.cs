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

    public void Add(User user)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            user.Log(method, $"{Logger.error} - {ex}");
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

    public void AddUserToList(User type, User user)
    {
        throw new NotImplementedException();
    }
}
