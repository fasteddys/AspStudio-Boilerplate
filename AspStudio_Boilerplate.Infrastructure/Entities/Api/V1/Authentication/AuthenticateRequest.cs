using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Infrastructure.Entities.Api.V1.Authentication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}