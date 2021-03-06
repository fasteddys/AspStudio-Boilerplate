namespace AspStudio_Boilerplate.Models.Authentication
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