using ExamManagement.Data;
using ExamManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamManagement.Controllers
{
    public class SubjectsController : BaseController
    {
        public SubjectsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public IActionResult Index() => View(db.Subjects);


        public async Task<ActionResult> New(Subject subject)
        {
            subject = new Subject { Name = subject.Name, CreatedOn = DateTime.Now };
            await db.Subjects.AddAsync(subject);
            await db.SaveChangesAsync();

            CreateNofification(NotificationType.Success, $"{subject.Name} has been created", "title");
            return RedirectToAction("Index");
        }

    }
}
