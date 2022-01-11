using AspStudio_Boilerplate.Entities.Models;

namespace AspStudio_Boilerplate.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}