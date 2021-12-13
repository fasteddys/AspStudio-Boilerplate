using AspStudio_Boilerplate.Areas.Users.Models;
using AspStudio_Boilerplate.Models;
using AspStudio_Boilerplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspStudio_Boilerplate.Areas.Users.Controllers
{
    [Area("Users")]
    public class AuditLogController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuditLogController(IUserService userService, UserManager<ApplicationUser> userManager, IMapper mapper,
            RoleManager<ApplicationRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
    }
}