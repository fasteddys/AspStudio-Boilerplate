using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Infrastructure.Entities.Users.ViewModels
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CreatedAt { get; set; }
    }
}