using ExamManagement.Data;
using ExamManagement.Models;
using ExamManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private SignInManager<IdentityUser> signInManager;
        private UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            ApplicationDbContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            db = dbContext;
        }

        [AllowAnonymous]
        public IActionResult LogIn() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn(SignInViewModel signInModel, string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var result = await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.keepSignedIn, false);

            var a = db.Students.ToList();
            if (db.Students.ToList().Any(s => s.Email.Equals(signInModel.Email, StringComparison.OrdinalIgnoreCase))) // if user is a student
                return RedirectToAction("Index", "Home", new { Area = "Student" });

            if (result.Succeeded)
                return LocalRedirect(returnUrl);

            ModelState.AddModelError("", "Invalid Sign In attempt");
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new StudentRegisterViewModel { CourseSelectList = new SelectList(db.Courses, "Id", "Name", "Select Course") };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Register(StudentRegisterViewModel model)
        {
            model.CourseSelectList = new SelectList(db.Courses, "Id", "Name", "Select Course");

            if (model.Password != model.ConfirmPassword) return View(model);

            if (db.Users.ToList().Any(u => u.Email.Equals(model.Student.Email, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("", "An account already exists with your email");
                return View(model);
            }

            var student = new Student
            {
                Email = model.Student.Email,
                FirstName = model.Student.FirstName,
                LastName = model.Student.LastName,
                EmailConfirmed = true,
                UserName = model.Student.Email,
                RegistrationDate = DateTime.Now
            };

            var res = await userManager.CreateAsync(student, model.Password);
            res = await userManager.AddToRoleAsync(student, "Student");
            await signInManager.SignInAsync(student, true);

            var studentCourse = new StudentCourse { CourseId = model.CourseId, StudentId = student.Id };
            db.StudentCourses.Add(studentCourse);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home", new { area = "Student", });
        }
    }
}
