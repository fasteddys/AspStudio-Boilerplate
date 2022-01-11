using AspStudio_Boilerplate.Infrastructure.Services;
using AspStudio_Boilerplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AspStudio_Boilerplate.Infrastructure.Configuration
{
    public class ApplicationRoleSeed : ISeeder
    {
        public void CreateRoles(RoleManager<ApplicationRole> _roleManager)
        {
            var roles = new List<string>
            {
                "Admin",
                "User"
            };

            foreach (var roleName in roles)
            {
                if (!_roleManager.RoleExistsAsync(roleName).Result)
                {
                    var role = new ApplicationRole { Name = roleName };

                    _roleManager.CreateAsync(role).Wait();
                }
            }
        }

        public Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            CreateRoles(roleManager);

            return Task.CompletedTask;
        }
    }
}