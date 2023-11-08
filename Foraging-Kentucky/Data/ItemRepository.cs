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

    public void Add(Item item)
    {
        var method = MethodBase.GetCurrentMethod().Name;
        try
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            item.Log(method, $"{Logger.error} - {ex}");
        }
    }
}
