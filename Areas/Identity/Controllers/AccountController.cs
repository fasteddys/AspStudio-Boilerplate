using System;
using System.Threading.Tasks;
using AspStudio_Boilerplate.Areas.Identity.Models;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspStudio_Boilerplate.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new {message = "Insufficient Fields."});
            
            var response = await _userService.RegisterWithIdentity(registerViewModel);

            if (response == IdentityResult.Failed()) return View(); // Return them back to the Register Screen
            else return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new {message = "Insufficient Fields."});
            var response = await _userService.Login(model);

            if (response == IdentityResult.Failed()) return View(); // Return them back to the Login Screen
            else return RedirectToAction("Index", "Dashboard");
        }
    }
}