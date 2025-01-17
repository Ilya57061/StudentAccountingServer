﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.Controllers
{

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("RegisterAdmin")]
        public IActionResult RegisterAdmin()
        {
            return Ok(_authService.RegisterAdmin());
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDto)
        {
            return Ok(_authService.Login(loginDto));
        }
        [Authorize(Roles = "Admin,DirectorOrganizational")]
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerModel)
        {
            if (_authService.UserExists(registerModel.Login))
                return BadRequest("UserName Is Already Taken");
            if (!_authService.Register(registerModel)) return BadRequest();
            return Ok("user was registered");
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] RefreshTokenDto model)
        {
            return Ok(_authService.Refresh(model));
        }
    }
}
