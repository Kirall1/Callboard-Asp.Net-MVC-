using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public ViewResult Index(int? adId) =>
            View(repository.Ads.FirstOrDefault(a => a.AdID == adId));

    }

}
