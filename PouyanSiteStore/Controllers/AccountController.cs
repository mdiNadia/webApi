using Application.Dtos.Account;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PouyanSiteStore.Controllers
{
 
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserAccessor _userAccessor;
        private readonly IMemoryCache _memoryCache;

        public AccountController(ILogger<AccountController> logger,IUserAccessor userAccessor, IMemoryCache memoryCache)
        {
            _logger = logger;
            this._userAccessor = userAccessor;
            this._memoryCache = memoryCache;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]LoginDto loginDto)
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
        [AllowAnonymous]
        [HttpGet("logOnlineUsers")]
        public IActionResult LogOnlineUsers()
        {

            var logUsers = _memoryCache.Get("OnlineUsers");
            //ViewBag.OnlineUsers = onlineUsers.Count;
            return Ok(logUsers);
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
