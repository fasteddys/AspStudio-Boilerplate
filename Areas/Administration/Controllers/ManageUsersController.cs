using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspStudio_Boilerplate.Areas.Administration.Models;
using AspStudio_Boilerplate.Entities.Models;
using AspStudio_Boilerplate.Entities.ViewModels.ManageUsers;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspStudio_Boilerplate.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ManageUsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ManageUsersController(IUserService userService, UserManager<ApplicationUser> userManager, IMapper mapper,
            RoleManager<ApplicationRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
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
            var evm = _mapper.Map<EditUserViewModel>(user);
            evm.Roles = (await _userManager.GetRolesAsync(user)).ToList();


            ViewBag.Roles = new MultiSelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");

            return View(evm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditUserViewModel evm)
        {
            if (evm.Id == null) return RedirectToAction("Edit");

            var user = await _userManager.FindByIdAsync(evm.Id.ToString());
            if (user == null) return RedirectToAction("Edit");


            _mapper.Map<EditUserViewModel, ApplicationUser>(evm, user);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return RedirectToAction("Index");
            var user = await _userManager.FindByIdAsync(id.ToString());
            return View(_mapper.Map<EditUserViewModel>(user));
        }
    }
}