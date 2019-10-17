using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CW.TestSystem.Identity.Infrastructure.Models.UserPresentation;
using CW.TestSystem.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CW.TestSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            (bool IsValid, string TokenBody, IList<string> Roles) = await _accountService.SignIn(loginModel);
            if (!IsValid) return Unauthorized("Wrong login or password");
            SetCookieSecurityToken(TokenBody);
            return Ok(Roles);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(RegistrationModel registrationModel)
        {
            var result = await _accountService.SignUp(registrationModel);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        [Authorize]
        [HttpGet("check")]
        public IActionResult CheckAuthorize()
        {
            return Ok();
        }

        private void SetCookieSecurityToken(string token)
        {
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    MaxAge = TimeSpan.FromMinutes(60)
                });
        }
    }
}