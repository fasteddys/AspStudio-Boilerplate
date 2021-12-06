using AspStudio_Boilerplate.Areas.Identity.Data;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspStudio_Boilerplate.Configuration
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