﻿using System.Net;
using AspStudio_Boilerplate.Infrastructure.Entities.Api;
using AspStudio_Boilerplate.Infrastructure.Entities.Api.V1.Authentication;
using AspStudio_Boilerplate.Infrastructure.Entities.Identity;
using AspStudio_Boilerplate.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspStudio_Boilerplate.Admin.Controllers.Api.V1
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
        public async Task<ApiResponse> Register(RegisterApiModel registerApiModel)
        {
            var response = _userService.RegisterWithApi(registerApiModel);

            if (await response == IdentityResult.Success) return new ApiResponse(HttpStatusCode.OK, "User created.");
            else return new ApiResponse(HttpStatusCode.BadRequest, "Invalid Email and/or Password.");
        }

        [HttpPost("authenticate")]
        public ApiResponse Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return new ApiResponse(HttpStatusCode.BadRequest, "Invalid Email and/or Password.");

            return new ApiResponse(HttpStatusCode.OK, "");
        }
    }
}