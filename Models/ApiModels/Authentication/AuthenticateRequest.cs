using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Models.Authentication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}