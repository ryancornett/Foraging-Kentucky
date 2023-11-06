using Foraging_Kentucky.Common;
using Microsoft.EntityFrameworkCore;

namespace Foraging_Kentucky.Data;
public class ForageContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public string DbPath { get; set; }

    public ForageContext()
    {
        var folder = Environment.SpecialFolder.Desktop;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "/db/forage-kentucky.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
