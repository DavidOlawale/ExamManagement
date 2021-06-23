﻿using ExamManagement.Data;
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

        public async Task<ActionResult> AddSubject(int courseId, int subjectId)
        {
            var course = await db.Courses.FindAsync(courseId);
            var subject = await db.Subjects.FindAsync(subjectId);

            if (course == null || subject == null)
                return BadRequest();

            if (!db.CourseSubjects.Any(s => s.SubjectId == subjectId && s.CourseId == courseId))
            {
                var courseSubject = new CourseSubject { CourseId = courseId, SubjectId = subjectId, AddedOn = DateTime.Now };
                db.CourseSubjects.Add(courseSubject);
                await db.SaveChangesAsync();
            }
            
            return RedirectToAction("Details", new { id = courseId });
        }


        public async Task<ActionResult> RemoveSubject(int courseId, int subjectId)
        {
            var course = await db.Courses.FindAsync(courseId);
            var subject = await db.Subjects.FindAsync(subjectId);

            if (course == null || subject == null)
                return BadRequest();

            var courseSubject = db.CourseSubjects.SingleOrDefault(s => s.SubjectId == subjectId && s.CourseId == courseId);
            if (courseSubject != null)
            {
                db.CourseSubjects.Remove(courseSubject);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = courseId });
        }
    }
}