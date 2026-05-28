using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Infrastructure.Identity
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleManager = services.
                GetRequiredService<RoleManager<IdentityRole>>();

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "Customer" };

            foreach(var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = "admin@gmail.com";
            var adminPassword = "Admin@123";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if(adminUser is null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = adminEmail
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }


        }
    }
}
