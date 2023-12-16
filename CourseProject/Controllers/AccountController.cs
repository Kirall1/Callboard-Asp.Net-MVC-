using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CourseProject.Models.ViewModels;


namespace CourseProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [HttpGet]
        public ViewResult SignIn()
        {
            return View(new SignInModel
            {
                Name = String.Empty,
                Password = String.Empty
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel signinmodel)
        {

            IdentityUser? user = await userManager.FindByNameAsync(signinmodel.Name);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                if ((await signInManager.
                    PasswordSignInAsync(user, signinmodel.Password, false, false)).Succeeded)
                {
                    return Redirect("/");
                }
            }
            ModelState.AddModelError("", "Invalid name or password");

            return View(signinmodel);
        }

        [HttpGet]
        public ViewResult SignUp()
        {
            return View(new SignUpModel
            {
                Phone = String.Empty,
                Name = String.Empty,
                Password = String.Empty,
                ConfirmPassword = String.Empty
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {

            var user = new IdentityUser { UserName = signUpModel.Name, PhoneNumber = signUpModel.Phone };
            var result = await userManager.CreateAsync(user, signUpModel.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                await signInManager.SignInAsync(user, false);
                return Redirect("/");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            // If registration fails, return to the SignUp view with the model to display errors
            return View(signUpModel);
        }
    }
}
