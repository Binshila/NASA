using Microsoft.EntityFrameworkCore;
using NASAWebApp.AppModels;

namespace NASAWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            // Register HttpClientFactory
            builder.Services.AddHttpClient();

            builder.Services.AddSession();


            builder.Services.AddDbContext<NasaContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"))
            );



            // Add cookie authentication
            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/NASA/Login"; // Redirect to login if not authenticated
                    options.ExpireTimeSpan = TimeSpan.FromDays(7); // Cookie expiration time
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            // Add authentication and authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
