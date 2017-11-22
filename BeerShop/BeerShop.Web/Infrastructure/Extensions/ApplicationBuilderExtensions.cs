namespace BeerShop.Web.Infrastructure.Extensions
{
    using BeerShop.Data;
    using BeerShop.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                                            .GetRequiredService<IServiceScopeFactory>()
                                            .CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<BeerShopDbContext>()
                    .Database
                    .Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                {
                    var adminName = WebConstants.AdminRole;

                    var roles = new[]
                    {
                        adminName,
                        WebConstants.ModeratorRole
                    };

                    foreach (var role in roles)
                    {
                        var hasRole = await roleManager.RoleExistsAsync(role);

                        if (!hasRole)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });
                        }
                    }

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = adminName,
                            FirstName = adminName,
                            LastName = adminName,
                            Email = "admin@admin.admin",
                            Address = "admin"
                        };

                        await userManager.CreateAsync(adminUser, "admin123");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
