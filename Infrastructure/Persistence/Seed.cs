using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class Seed
    {

        public static async Task SeedData(DataContext context, UserManager<ApplicationUser> userManager, RoleManager<AppRole> roleManager, IConfiguration _configuration)
        {
            if (!await context.Roles.AnyAsync())
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
            if (!await userManager.Users.AnyAsync())
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
            if (!await context.Transactions.AnyAsync())
            {
                string targetFolder = Path.Combine("../../Application", "Queries", "Transactions.sql");
                FileInfo file = new FileInfo(targetFolder);
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = file.OpenText().ReadToEnd();
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    await con.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    await con.CloseAsync();
                }
            }

        }

    }
}
