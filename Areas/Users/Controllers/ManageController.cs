using AspStudio_Boilerplate.Areas.Users.Models;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace AspStudio_Boilerplate.Areas.Users.Controllers
{
    [Area("Users")]

    public class ManageController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ManageController(IUserService userService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
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
                    Email = applicationUser.Email,
                    Id = applicationUser.Id
                };
                users.Add(ivm);
            }
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return RedirectToAction("Index");
            var evm = _mapper.Map()
            return View(evm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel evm)
        {
            if (evm.Id == null) return RedirectToAction("Edit");

            var user = await _userManager.FindByIdAsync(evm.Id.ToString());
            if (user == null) return RedirectToAction("Edit");

            var newEVM = _mapper.Map<ApplicationUser>(evm);

        }
    }
}