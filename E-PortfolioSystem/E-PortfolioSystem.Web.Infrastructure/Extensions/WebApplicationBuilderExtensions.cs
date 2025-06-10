using E_PortfolioSystem.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;

namespace E_PortfolioSystem.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    { 
        public static void AddApplicationServices(
            this IServiceCollection services,
            Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (var implementationType in serviceTypes)
            {
                Type? interfaceType = implementationType
                    .GetInterface($"I{implementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface type is provided for service {implementationType.Name}!");
                }

                services.AddScoped(interfaceType, implementationType);
            }
        }

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager = 
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole<Guid>> roleManager = 
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser = 
                    await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }

        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            RoleManager<IdentityRole<Guid>> roleManager = 
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync(StudentRoleName))
                {
                    IdentityRole<Guid> studentRole = new IdentityRole<Guid>(StudentRoleName);
                    await roleManager.CreateAsync(studentRole);
                }

                if (!await roleManager.RoleExistsAsync(TeacherRoleName))
                {
                    IdentityRole<Guid> teacherRole = new IdentityRole<Guid>(TeacherRoleName);
                    await roleManager.CreateAsync(teacherRole);
                }

                if (!await roleManager.RoleExistsAsync(HRRoleName))
                {
                    IdentityRole<Guid> hrRole = new IdentityRole<Guid>(HRRoleName);
                    await roleManager.CreateAsync(hrRole);
                }
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
