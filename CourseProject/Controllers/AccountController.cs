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

        [HttpGet]
        public ViewResult SignUp() => View();

        [HttpGet]
        public ViewResult SignIn() => View();
    }
}
