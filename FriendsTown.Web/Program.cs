using FriendsTown.Data;
using FriendsTown.Data.Repositories;
using FriendsTown.Transversal;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FriendsTown.Web.Hubs;

namespace FriendsTown.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();

            string apiUrl = builder.Configuration.GetValue<string>("ApiUrl");
            builder.Services.AddHttpClient("FriendsTownWebApi", c => 
                c.BaseAddress = new Uri(apiUrl));

            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
            builder.Services.AddScoped<IFriendRepository, FriendRepository>();
            builder.Services.AddScoped<INewsRepository, NewsRepository>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddDbContext<FriendsTownContext>(options =>
                options.UseSqlServer("name=connectionStrings:FriendsTown"));

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FriendsTown.Web",
                    Version = "v1"
                });
            });

            builder.Services.AddCors();
            

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller = Home}/{action = Index }/{id?}");
            });

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapHub<BoardHub>("/boardhub");
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiEndpoint");
            });

            app.UseCors(builder => builder.SetIsOriginAllowed(origin => true));

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Append("X-Frame-Options", "DENY");
                await next.Invoke();
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
