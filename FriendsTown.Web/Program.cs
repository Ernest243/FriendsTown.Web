using FriendsTown.Data;
using FriendsTown.Data.Repositories;
using FriendsTown.Transversal;
using Microsoft.EntityFrameworkCore;

namespace FriendsTown.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
            builder.Services.AddDbContext<FriendsTownContext>(options =>
                options.UseSqlServer("name=connectionStrings:FriendsTown"));
            

            // Set up Database
            var options = new DbContextOptionsBuilder<FriendsTownContext>()
                .UseSqlServer(builder.Configuration.GetConnectionString("FriendsTown"))
                .Options;

            FriendsTownContext contexto = new FriendsTownContext(options);
            contexto.Database.EnsureCreated();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
