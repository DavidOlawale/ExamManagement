using ExamManagement.Data;
using ExamManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Areas.Student.Controllers
{
    public class ExamController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        public ExamController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            db = dbContext;
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            var student = db.Students.Find(userManager.GetUserId(User));
            return View(student);
        }

        public async Task<ActionResult> Enroll(string studentId, int scheduleId)
        {
            var student = await  db.Students.FindAsync(studentId);
            var schedule = await db.ExamSchedules.FindAsync(scheduleId);

            if (student == null || schedule == null) return BadRequest();

            var scheduleEnrolment = db.ExamScheduleEnrollments.SingleOrDefault(e => e.StudentId == studentId && e.ExamScheduleId == scheduleId);

            if (scheduleEnrolment == null)
            {
                //ensure student enrolled for the course before enrolling the student for the exam schedule
                if (student.StudentCourses.Any(s => s.CourseId == schedule.CourseId))
                {
                    scheduleEnrolment = new ExamScheduleEnrollment
                    {
                        EnrolledOn = DateTime.Now,
                        ExamScheduleId = scheduleId,
                        StudentId = studentId
                    };
                    db.ExamScheduleEnrollments.Add(scheduleEnrolment);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("index");
        }
    }
}
