using Microsoft.EntityFrameworkCore;
namespace E_PortfolioSystem.Web
{
    using E_PortfolioSystem.Data;
    using E_PortfolioSystem.Data.Models;
    using E_PortfolioSystem.Services.Data.Interfaces;
    using E_PortfolioSystem.Web.Hubs;
    using E_PortfolioSystem.Web.Infrastructure.Extensions;
    using E_PortfolioSystem.Web.Infrastructure.Filters;
    using E_PortfolioSystem.Web.Infrastructure.Middlewares;
    using Hangfire;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using static E_PortfolioSystem.Common.GeneralApplicationConstants;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<EPortfolioDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddMemoryCache();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                            builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                            builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                            builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                            builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                            builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<EPortfolioDbContext>();

            builder.Services.AddScoped<RoleManager<IdentityRole<Guid>>>();

            builder.Services.AddApplicationServices(typeof(IProfileService));

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            builder.Services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddHangfireServer();

            builder.Services.AddControllersWithViews();
            //.AddMvcOptions(options =>
            //{
            //    options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
            //});

            builder.Services.AddSignalR();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    context.Response.Redirect("/Home/Error");
                }
            });

            app.UseMiddleware<OnlineUsersMiddleware>();

            app.SeedAdministrator(DevelopmentAdminEmail);
            app.SeedRoles();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });

            RecurringJob.AddOrUpdate<INotificationService>(
                "CheckProjectDeadlines",
                service => service.GenerateDeadlineNotificationsAsync(),
                Cron.Daily(9)
            );

            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}
