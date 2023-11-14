using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrCarsOriginal.Data;

namespace OrCarsOriginal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllerRoute(
                name: "CarIndex",
                pattern: "{controller=Car}/{action=Index}");

                endPoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Details}/{id?}");

                endPoints.MapControllerRoute(
                name: "CarDetails",
                pattern: "{controller=Car}/{action=Details}/{id?}/{Text?}");

            });
            app.MapRazorPages();

            app.Run();
        }
    }
}