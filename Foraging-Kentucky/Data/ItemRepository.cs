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

    public Item Retrieve(string name)
    {
        return _context.Items.FirstOrDefault(item => item.Name == name);
    }

    public bool CheckIfExists(string name)
    {
        return _context.Items.Any(u => u.Name == name);
    }

    public async Task AddUserToList(Item item, User user)
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
}
