using AspStudio_Boilerplate.Entities.Models;

namespace AspStudio_Boilerplate.Infrastructure.CoreModels.ApiModels.Authentication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(ApplicationUser user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Token = token;
        }
    }
}