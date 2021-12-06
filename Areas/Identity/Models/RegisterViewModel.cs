using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Areas.Identity.Models
{
    public class RegisterViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")] public string ConfirmPassword { get; set; }
        [Required] public string FirstName { get; set; }
        public string LastName { get; set; } = "";
        public string ReturnUrl { get; set; }
    }
}