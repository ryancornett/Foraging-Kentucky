using Foraging_Kentucky.Data;
using Foraging_Kentucky.Common;
using Foraging_Kentucky.Domain;

namespace Foraging_Kentucky;
public class Program
{
    public static void Main(string[] args)
    {
        ClearDb.ClearDatabase();

        SeedDb.SeedAndVerify();

        #region App Configurations
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<IRepository<Item>, ItemRepository>();
        builder.Services.AddSingleton<IRepository<User>, UserRepository>();
        builder.Services.AddSingleton<IRepository<Recipe>, RecipeRepository>();

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
