using FitOl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("User");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "User" });
            }

            var adminUser = await userManager.FindByNameAsync("fatih");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "fatih",
                    Email = "fatihsozuer0@gmail.com"
                };
                await userManager.CreateAsync(user, "9s3832hsl611");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
