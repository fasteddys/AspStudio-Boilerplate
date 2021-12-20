using AspStudio_Boilerplate.Infrastructure.Entities.Identity;

namespace AspStudio_Boilerplate.Infrastructure.Entities.Dashboard.ViewModels
{
    public class DashboardViewModel
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}