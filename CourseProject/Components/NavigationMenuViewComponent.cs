using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using CourseProject.Models;

namespace CourseProject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IPlatformRepository repository;
        public NavigationMenuViewComponent(IPlatformRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Ads
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
