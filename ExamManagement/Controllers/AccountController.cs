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

        public IActionResult LogIn() => View();
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(SignInModel signInModel, string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var result = await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.keepSignedIn, false);
            if (result.Succeeded)
                //return new Redi +rectToActionResult("Index", "Home", null);
                return LocalRedirect(returnUrl);

            ModelState.AddModelError("", "Invalid SignIn attempt");
            return View();
        }
    }
}
