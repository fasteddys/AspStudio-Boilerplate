using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Infrastructure.Entities.Users.ViewModels
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        public int Id { get; set; }
        public List<string> Roles { get; set; }

    }
}
