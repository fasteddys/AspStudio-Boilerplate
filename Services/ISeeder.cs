using System;
using System.Threading.Tasks;
using AspStudio_Boilerplate.Areas.Identity.Data;

namespace AspStudio_Boilerplate.Services
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}