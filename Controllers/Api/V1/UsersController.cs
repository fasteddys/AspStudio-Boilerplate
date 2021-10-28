using System.Net;
using System.Threading.Tasks;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Models.Authentication;
using AspStudio_Boilerplate.Models.ViewModels;
using AspStudio_Boilerplate.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspStudio_Boilerplate.Controllers.Api.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ApiResponse> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return new ApiResponse(HttpStatusCode.BadRequest, "Please provide a valid First Name, Email, and Password.");
            
            var user = await _userManager.FindByNameAsync(registerViewModel.Email);
            if (user != null)
            {
                return new ApiResponse(HttpStatusCode.Forbidden, "A user already exists with this Email.");
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName
            };
            await _userManager.CreateAsync(newUser, registerViewModel.Password);

            return new ApiResponse(HttpStatusCode.OK, "User created.");
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Email or Password is incorrect" });

            return Ok(response);
        }
    }
}