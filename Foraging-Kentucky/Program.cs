using Foraging_Kentucky.Data;
using Foraging_Kentucky.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Foraging_Kentucky
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*using var contextTest = new ForageContext();
            Item testThis = new Item("Test");
            testThis.Type = ItemOptions.ItemTypes[3];
            testThis.Description = "I sure hope this works.";
            testThis.Users.Add(new User("Bob Vila", "bob@vila.net"));
            contextTest.Items.Add(testThis);
            contextTest.SaveChanges();
            Console.WriteLine("Is this working?");*/

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
        }
    }
}