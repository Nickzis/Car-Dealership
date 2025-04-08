using Fitness_Tracker.Model;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Tracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            
            builder.Services.AddDbContext<TrackerContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-D0CPLTH\\SQLEXPRESS01;Database=TrackerDB;Trusted_Connection=True;TrustServerCertificate=True");
            });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
