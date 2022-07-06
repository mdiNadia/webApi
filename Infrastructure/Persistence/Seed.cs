using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class Seed
    {

        public static async Task SeedData(DataContext context, UserManager<ApplicationUser> userManager, RoleManager<AppRole> roleManager, IConfiguration _configuration)
        {
            if (!context.Roles.Any())
            {
                var list = new List<AppRole> {
                    new AppRole { Name = "Admin" },
                    new AppRole { Name = "Security" },
                    new AppRole { Name = "Seller" },
                    new AppRole { Name = "SuperUser" },
                    new AppRole { Name = "Support" },
                    new AppRole { Name = "User" },

                };
                foreach (var role in list)
                    await roleManager.CreateAsync(role);
                await context.SaveChangesAsync();
            };
            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser> {
                    new ApplicationUser {
                    UserName = "h.sharafi@hotmail.com",
                    Email = "h.sharafi@hotmail.com",
                    FirstName = "حسن",
                    LastName = "شرفی",
                    CreateDate = DateTime.Now
                    }
                };
                foreach (var user in users)
                    await userManager.CreateAsync(user, "123456");

                //var ApplicationUser = userManager.Users.FirstOrDefault();
                //await userManager.AddToRoleAsync(ApplicationUser, "Administrator");

                await context.SaveChangesAsync();
                //foreach (var user in await context.Users.ToListAsync())
                //{
                //    await userManager.AddToRoleAsync(user, "Admin");
                //    await userManager.AddToRoleAsync(user, "SuperUser");
                //}
                //await context.SaveChangesAsync();
            }



        }

    }
}
