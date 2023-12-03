using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private IPlatformRepository repository;

        public HomeController(IPlatformRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index() => View(repository.Ads);
    }

}
