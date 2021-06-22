using ExamManagement.Data;
using ExamManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Controllers
{
    public class CoursesController : BaseController
    {
        public CoursesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        
        public IActionResult Index() => View(db.Courses);


        public async Task<ActionResult> New(Course course)
        {
            course = new Course { Name = course.Name, CreatedOn = DateTime.Now };
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) => View(db.Courses.Find(id));
    }
}
