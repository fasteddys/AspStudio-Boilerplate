using AspStudio_Boilerplate.Areas.Identity.Data;
using System;
using System.Threading.Tasks;

namespace AspStudio_Boilerplate.Services
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}