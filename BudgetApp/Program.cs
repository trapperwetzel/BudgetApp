using BudgetApp.Data;
using BudgetApp.Models;
using BudgetApp.Services;

namespace BudgetApp {
    public class Program {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DapperContext (adjust lifetime as needed: Scoped, Singleton, etc.)
            builder.Services.AddScoped<BudgetService>();
           
            builder.Services.AddScoped<BudgetQueries>();
            builder.Services.AddScoped<DapperContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
