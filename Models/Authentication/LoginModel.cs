using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Models.Authentication
{
    public class LoginModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "UEmail is required")]  
        public string Email { get; set; }  
  
        [Required(ErrorMessage = "Password is required")]  
        public string Password { get; set; }  
    }
}