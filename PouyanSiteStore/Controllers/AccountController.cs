using Application.Dtos.Account;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace PouyanSiteStore.Controllers
{
 
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserAccessor _userAccessor;

        public AccountController(ILogger<AccountController> logger,IUserAccessor userAccessor)
        {
            _logger = logger;
            this._userAccessor = userAccessor;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            var user = await _userAccessor.LoginAsync(loginDto);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var user = await _userAccessor.RegisterAsync(registerDto);
            return Ok(user);
        }
        [HttpGet("currentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userAccessor.GetCurrentUserAsync();
            return Ok(user);
        }

        [HttpGet("logOut")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                var result = await _userAccessor.ExitAsync();
                if (result == 200)
                {
                    return Ok("/");
                }
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }

            return BadRequest();
        }
    }
}
