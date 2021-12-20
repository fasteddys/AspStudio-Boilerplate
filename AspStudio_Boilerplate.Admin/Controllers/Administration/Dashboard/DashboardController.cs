using AspStudio_Boilerplate.Infrastructure.Entities.Identity;
using AspStudio_Boilerplate.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AspStudio_Boilerplate.Infrastructure.Entities;
using AspStudio_Boilerplate.Infrastructure.Entities.Dashboard.ViewModels;

namespace AspStudio_Boilerplate.Admin.Controllers.Administration.Dashboard
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            DashboardViewModel dvm = new DashboardViewModel()
            {
                User = user,
                UserId = user.Id
            };
            return View(dvm);
        }
    }
}