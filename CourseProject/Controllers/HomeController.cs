using CourseProject.Models;
using CourseProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private IPlatformRepository repository;
        public int PageSize = 10;

        public HomeController(IPlatformRepository repository)
        {
            this.repository = repository;
        }
        [AllowAnonymous]
        public ViewResult Index(string? category, int adPage = 1)
        {
            return View(new AdsListViewModel
            {
                Ads = repository.Ads
                    .Where(a => category == null || a.Category == category)
                    .OrderBy(a => a.AdID)
                    .Skip((adPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = adPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Ads.Count() : repository.Ads.Where(e => e.Category == category).Count()
                }
            });
        }

        [Authorize]
        public ViewResult UserAds(int adPage = 1)
        {
            string userName = User.Identity.Name;
            return View(new AdsListViewModel
            {
                Ads = repository.Ads
                    .Where(a => a.Owner == userName)
                    .OrderBy(a => a.AdID)
                    .Skip((adPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = adPage,
                    ItemsPerPage = PageSize,
                    TotalItems = userName == null ?
                    repository.Ads.Count() :
                    repository.Ads.Where(e => e.Owner == userName).Count()
                }
            });
        }
    }

}
