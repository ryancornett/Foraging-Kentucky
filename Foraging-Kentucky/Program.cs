using Foraging_Kentucky.Data;
using Foraging_Kentucky.Common;
using Foraging_Kentucky.Domain;

namespace Foraging_Kentucky;
public class Program
{
    public static void Main(string[] args)
    {
        #region Clear and/or Seed Database
        // Resets the database when starting the program; comment out to truly persist data
        // ClearDb.ClearDatabase();

        // Seeds the database when starting the program; comment out to avoid identitcal data entries
        SeedDb.SeedAndVerify();
        #endregion

        #region App Configurations
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddTransient<IRepository<Item>, ItemRepository>();
        builder.Services.AddTransient<IRepository<User>, UserRepository>();
        builder.Services.AddTransient<IRepository<Recipe>, RecipeRepository>();

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
