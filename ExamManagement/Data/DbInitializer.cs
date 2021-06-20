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
        public DbInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task InitializerAsync()
        {
            var admin = new Admin
            {
                Email = "admin@app.com",
                EmailConfirmed = true,
                UserName = "admin@app.com"
            };

            await userManager.CreateAsync(admin, "password@123#");
            
        }
    }
}
