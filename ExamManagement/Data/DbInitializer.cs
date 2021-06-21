using ExamManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Data
{
    public class DbInitializer
    {
        private ApplicationDbContext dbContext;
        private UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task InitializerAsync()
        {
            var admin = new Admin
            {
                Email = "admin@app.com",
                EmailConfirmed = true,
                UserName = "admin@app.com"
            };

            var res = await userManager.CreateAsync(admin, "password@123#");
            if (res.Succeeded)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await userManager.AddToRoleAsync(admin, "Admin");
            }
            
        }
    }
}
