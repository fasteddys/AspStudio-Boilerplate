using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Models
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