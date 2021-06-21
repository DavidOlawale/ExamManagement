using ExamManagement.Data;
using ExamManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamManagement.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            db = dbContext;
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
