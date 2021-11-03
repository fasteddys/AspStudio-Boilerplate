using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspStudio_Boilerplate.Data;
using AspStudio_Boilerplate.Helpers;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Models.ApiModels;
using AspStudio_Boilerplate.Models.Authentication;
using AspStudio_Boilerplate.Models.ViewModelsgitkr
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AspStudio_Boilerplate.Services
{
    public interface IUserService
    {
        Task<IdentityResult> Login(LoginViewModel model); // Login is for the backend
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model); // Authenticate is for the Api
        Task<ApplicationUser> GetById(int id);
        Task<IdentityResult> RegisterWithApi(RegisterApiModel model);
        Task<IdentityResult> RegisterWithIdentity(RegisterViewModel model);
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _userManager = userManager;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            

            // return null if user not found
            if (user == null) 
                return null;

            // Check password
            if (await _userManager.CheckPasswordAsync(user, model.Password))
                return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        
        public async Task<IdentityResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            

            // return false if user not found
            if (user == null) 
                return IdentityResult.Failed();

            // Check password
            if (await _userManager.CheckPasswordAsync(user, model.Password))
                return IdentityResult.Failed();

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> RegisterWithApi(RegisterApiModel model)
        {

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                return IdentityResult.Failed();
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            return result;
        }
        
        public async Task<IdentityResult> RegisterWithIdentity(RegisterViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                return IdentityResult.Failed();
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            
            var result = await _userManager.CreateAsync(newUser, model.Password);

            return result;
        }

        public async Task<ApplicationUser> GetById(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        // helper methods

        private string generateJwtToken(ApplicationUser user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}