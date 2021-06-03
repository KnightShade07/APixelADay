using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public class IdentityHelper
    {
        //Administrators can do things like update, edit, and create
        //new pixel arts
        public const string Administrator = "Administrator";
        //users can look at various pages and pixel arts,
        //but cannot access administrator pages like where
        //the admins create new pixel art pieces.
        public const string User = "User";
        public static void SetIdentityOptions(IdentityOptions options)
        {
            //setting sign in options.
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            //sets password strength.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 10;
            options.Password.RequireNonAlphanumeric = false;

        }

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            //create role if it does not exist.
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        internal static async Task CreateDefaultAdministrator(IServiceProvider serviceProvider)
        {
            //Admin login details.
            const string email = "admin@yahoo.com";
            const string username = "Admin";
            const string password = "TestPassword356";

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //checks if users are in the database.
            if(userManager.Users.Count() == 0)
            {
                IdentityUser admin = new IdentityUser()
                {
                    Email = email,
                    UserName = username
                };
                //create the administrator.
                await userManager.CreateAsync(admin, password);
                //add to admin role.
                await userManager.AddToRoleAsync(admin, Administrator);
            }
        }
    }
}
