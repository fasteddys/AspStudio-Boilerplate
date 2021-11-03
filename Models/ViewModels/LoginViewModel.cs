using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}