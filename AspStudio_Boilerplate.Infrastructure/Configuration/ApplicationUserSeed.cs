using AspStudio_Boilerplate.Entities.Models;
using AspStudio_Boilerplate.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AspStudio_Boilerplate.Infrastructure.Configuration
{
    public class ApplicationUserSeed : ISeeder
    {
        public void CreateAdminUser(UserManager<ApplicationUser> _userManager)
        {
            IdentityResult result;
            if (_userManager.FindByNameAsync("admin@test.com").Result != null)
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
                FirstName = "Admin"
            };

            try
            {
                result = _userManager.CreateAsync(adminUser, "Password123!").Result;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while creating the admin user: " + e.InnerException);
            }

            if (!result.Succeeded)
            {
                throw new Exception("The following error(s) occurred while creating the admin user: " +
                                    string.Join(" ", result.Errors.Select(e => e.Description)));
            }

            _userManager.AddToRoleAsync(adminUser, "User").Wait();
            _userManager.AddToRoleAsync(adminUser, "Admin").Wait();
        }

        public Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            CreateAdminUser(userManager);

            return Task.CompletedTask;
        }
    }
}