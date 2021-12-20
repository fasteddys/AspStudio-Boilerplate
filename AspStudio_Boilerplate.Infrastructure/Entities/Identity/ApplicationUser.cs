using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AspStudio_Boilerplate.Infrastructure.Entities.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {


        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual string FullName => FirstName.Trim() + " " + LastName?.Trim();


    }
}