﻿using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.JWT
{
    public interface IJwtGenerator
    {
        string CreateToken(ApplicationUser user);
    }
}
