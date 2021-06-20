using ExamManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamManagement.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult SignIn() => View();
        

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInModel signInModel)
        {
            var result = await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.keepSignedIn, false);
            if (result.Succeeded)
                //return new RedirectToActionResult("Index", "Home", null);
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid SignIn attempt");
            return View();
        }
    }
}
