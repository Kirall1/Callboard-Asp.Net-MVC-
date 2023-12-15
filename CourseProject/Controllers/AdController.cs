using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AdController : Controller
    {
        private IPlatformRepository repository;

        public AdController(IPlatformRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(int? adId) =>
            View(repository.Ads.FirstOrDefault(a => a.AdID == adId));

    }

}
