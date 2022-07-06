using Application.Dtos.Account;
using Application.Interfaces;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Identity
{
    public interface IUserAccessor : IGenericRepository<ApplicationUser>
    {
        Task<UserInfoDto> LoginAsync(LoginDto loginDto);
        Task<UserInfoDto> RegisterAsync(RegisterDto registerDto);
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<int> ExitAsync();
    }
}
