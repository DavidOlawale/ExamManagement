using ExamManagement.Data;
using ExamManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamManagement.Controllers
{

    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext db;

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async  Task<ActionResult> Index()
        {
            var model = new AdminDashboardViewModel
            {
                User = await userManager.GetUserAsync(User),
                Courses = db.Courses,
                Subjects = db.Subjects
            };
            
            return View(model);
        }

    }
}
