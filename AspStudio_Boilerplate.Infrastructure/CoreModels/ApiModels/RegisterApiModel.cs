using System.ComponentModel.DataAnnotations;

namespace AspStudio_Boilerplate.Models.ApiModels
{
    public class RegisterApiModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string FirstName { get; set; }
        public string LastName { get; set; } = "";
    }
}