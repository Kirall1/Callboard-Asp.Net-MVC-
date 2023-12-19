using CourseProject.Models;
using CourseProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;

namespace CourseProject.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private IPlatformRepository repository;

        public AdminController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr, IPlatformRepository repo)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            repository = repo;
        }


        [HttpGet]
        [Authorize]
        public IActionResult UsersManager()
        {
            List<UsersManagerViewModel> UsersList = new();
            foreach (var user in userManager.Users)
            {
                if (user.UserName == "Admin") continue;
                UsersList.Add(new UsersManagerViewModel()
                {
                    Name = user.UserName,
                    Phone = user.PhoneNumber,
                    AdCount = repository.Ads.Select(u => u.Owner).Where(u => u == user.UserName).Count()
                });
            }
            return View(UsersList);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string name)
        {
            if (name == "Admin") return RedirectToAction("UsersManager");
            foreach (var ad in repository.Ads.Where(u => u.Owner == name))
            {
                repository.DeleteAd(ad);
            }
            repository.SaveChanges();
            await userManager.DeleteAsync(userManager.FindByNameAsync(name).Result);

            return RedirectToAction("UsersManager");
        }
    }
}
