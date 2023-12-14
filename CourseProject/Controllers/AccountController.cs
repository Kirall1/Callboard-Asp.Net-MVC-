using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AccountController : Controller
    {
        private IPlatformRepository repository;

        public AccountController(IPlatformRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult SignUp() => View(new User());

        public ViewResult SignIn() => View(new User());

        //public ViewResult Index() => View(new User());
    }
}
