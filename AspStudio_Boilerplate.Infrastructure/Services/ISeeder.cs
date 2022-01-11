namespace AspStudio_Boilerplate.Infrastructure.Services
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}