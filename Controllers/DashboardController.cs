using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Models.ViewModels;
using AspStudio_Boilerplate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspStudio_Boilerplate.Controllers
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