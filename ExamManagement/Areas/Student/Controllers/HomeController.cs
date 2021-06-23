using ExamManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Areas.Student.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        public HomeController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            db = dbContext;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var student = db.Students.Find(userManager.GetUserId(User));
            return View(student);
        }
    }
}
