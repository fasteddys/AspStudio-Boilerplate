﻿using AspStudio_Boilerplate.Infrastructure.Entities.Identity;
using AspStudio_Boilerplate.Infrastructure.Entities.Identity.ViewModels;
using AspStudio_Boilerplate.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspStudio_Boilerplate.Admin.Controllers.Identity
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
            if (!ModelState.IsValid) return RedirectToAction("Register");

            var response = await _userService.RegisterWithIdentity(registerViewModel);

            return RedirectToAction(response.Succeeded == false ? "Register" : "Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new { message = "Insufficient Fields." });
            var response = await _userService.Login(model);

            if (response.Succeeded == false) return RedirectToAction("Login"); // Return them back to the Login Screen
            else return RedirectToAction("Index", "Dashboard");
        }
    }
}