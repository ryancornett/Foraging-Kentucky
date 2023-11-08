using Foraging_Kentucky.Data;
using Foraging_Kentucky.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Data.Sqlite;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Foraging_Kentucky;
public class Program
{
    public static void Main(string[] args)
    {
        #region Clears the table, but not auto-incremented ID integers
        var folder = Environment.SpecialFolder.Desktop;
        var path = Environment.GetFolderPath(folder);
        string DbPath = Path.Join(path, "/db/forage-kentucky.db");

        string connectionString = $"Data Source={DbPath}";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (SqliteCommand command = new SqliteCommand("DELETE FROM Items", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'Items'", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("DELETE FROM Users", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'Users'", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("DELETE FROM ItemUser", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'ItemUser'", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("DELETE FROM Recipes", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'Recipes'", connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        Console.WriteLine("Records cleared from the table.");

        #endregion

        var seedCheck = Seed.SeedDatabase();
        using var context = new ForageContext();
        if (!context.Items.Any(id => id.Id == 1))
        {
            Logger.Log(seedCheck, $"{Logger.error} No items were added to the database.");
        }
        else { Logger.Log(seedCheck, $"{Logger.success} The database was seeded."); }

        #region App Configurations
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
        #endregion
    }
}