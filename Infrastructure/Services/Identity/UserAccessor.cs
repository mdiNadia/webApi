using Application.Dtos.Account;
using Application.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Infrastructure.Services.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserAccessor : GenericRepository<ApplicationUser>, IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserAccessor(IHttpContextAccessor httpContextAccessor, DataContext context, IConfiguration configuration, UserManager<ApplicationUser> userManager, IJwtGenerator jwtGenerator, SignInManager<ApplicationUser> signInManager) : base(context, configuration)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
            this._jwtGenerator = jwtGenerator;
            this._signInManager = signInManager;
        }

        public async Task<UserInfoDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new RestException(HttpStatusCode.Unauthorized.ToString());

            var result = await _signInManager
                    .CheckPasswordSignInAsync(user, loginDto.PassWord, false);

            if (result.Succeeded)
            {
                // TODO: generate token
                return new UserInfoDto
                {
                    DisplayName = user.FirstName + user.LastName,
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                    photo = null
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized.ToString());
        }
        public async Task<UserInfoDto> RegisterAsync(RegisterDto registerDto)
        {
            if (context.Users.Where(x => x.Email == registerDto.Email).Any())
                throw new RestException("Email already exists");

            if (context.Users.Where(x => x.UserName == registerDto.Username).Any())
                throw new RestException("Username already exists");

            var user = new ApplicationUser
            {

                Email = registerDto.Email,
                UserName = registerDto.Username,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Photo = registerDto.Photo,
                CreateDate = registerDto.CreateDate

            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return new UserInfoDto
                {
                    DisplayName = user.FirstName + user.LastName,
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                    photo = user.Photo

                };
            }

            throw new Exception("Problem creating user");
        }
        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            string Email = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByNameAsync(Email);
           
            return user;
        }
        public async Task<int> ExitAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
                //////////////////////////////////////////////
                //باید
                //jwt
                //را هم از کار بندازیم و منقضی کنیم
                /////////////////////////////////////////////
                return 200;
            }
            catch (Exception err)
            {
                throw err;
            }
           

        }
    }
}
