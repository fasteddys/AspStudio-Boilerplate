using System.Collections.Generic;
using System.Threading.Tasks;
using AspStudio_Boilerplate.Areas.Identity.Models;
using AspStudio_Boilerplate.Areas.Users.Models;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspStudio_Boilerplate.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var list = await _userManager.GetUsersInRoleAsync("User");
            var users = new List<IndexViewModel>();
            foreach (var applicationUser in list)
            {
                var ivm = new IndexViewModel()
                {
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Email = applicationUser.Email
                };
                users.Add(ivm);
            }
            return View(users);
        }
    }
}