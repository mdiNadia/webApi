using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Account
{
    public class UserInfoDto
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public Guid? photo { get; set; }
        public string Token { get; set; }
    }
}
