using System.Security.Principal;
using CourseProject.Models;
using CourseProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CourseProject.Controllers
{
    public class AdController : Controller
    {
        private IPlatformRepository repository;
        private IWebHostEnvironment webHostEnvironment;
        private UserManager<IdentityUser> userManager;

        public AdController(IPlatformRepository repository, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public ViewResult Index(int? adId) =>
            View(repository.Ads.FirstOrDefault(a => a.AdID == adId));



        [Authorize]
        [HttpGet]
        public IActionResult AdEditor(int? adId)
        {
            if (adId == 0)
            {
                return View(new AdViewModel() { Categories = repository.Categories.Select(x => x.Name) });
            }
            if (User.Identity?.Name == repository.Ads?.FirstOrDefault(a => a.AdID == adId)?.Owner)
            {
                Ad? ad = repository.Ads?.FirstOrDefault(a => a.AdID == adId);
                return View(new AdViewModel()
                {
                    AdID = ad?.AdID,
                    Name = ad?.Name,
                    City = ad?.City,
                    Description = ad?.Description,
                    Photos = ad?.Photos,
                    Price = ad?.Price,
                    Categories = repository.Categories.Select(x => x.Name),
                    UserPhotos = new FormFileCollection()
                });
            }
            return View(new AdViewModel() { Categories = repository.Categories.Select(x => x.Name) });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AdEditor(AdViewModel model)
        {
            if (model.AdID == 0 || model.AdID == null)
            {
                long? i = repository.Ads.Max(e => e.AdID) + 1;
                string targetDirectory = Path.Combine(webHostEnvironment.WebRootPath, $"Photos/{i}/");

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                string photos = "";
                for (int j = 0; j < model.UserPhotos.Count; j++)
                {
                    if (model.UserPhotos[j].Length > 0)
                    {
                        // Генерируем уникальное имя файла
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.UserPhotos[j].FileName);
                        if (j == model.UserPhotos.Count - 1)
                        {
                            photos = photos + $"/Photos/{i}/" + fileName;
                        }
                        else
                        {
                            photos = photos + $"/Photos/{i}/" + fileName + "|";
                        }
                        // Полный путь к файлу
                        var filePath = Path.Combine(targetDirectory, fileName);

                        // Сохраняем файл на диск
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.UserPhotos[j].CopyToAsync(stream);
                        }
                    }
                }
                Ad ad = new Ad()
                {
                    Name = model.Name,
                    City = model.City,
                    OwnerPhone = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name)?.PhoneNumber,
                    Description = model.Description,
                    Photos = photos,
                    Price = model.Price,
                    Owner = User.Identity?.Name,
                    Category = repository.Categories.FirstOrDefault(c => c.Name == model.Category).Name,
                    CreatedDate = DateTime.Now
                };
                repository.CreateAd(ad);
            }
            else
            {

                long? i = model.AdID;
                string targetDirectory = Path.Combine(webHostEnvironment.WebRootPath, $"Photos/{i}/");
                string? photos = model.Photos;
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                List<string> existingFiles = Directory.GetFiles(targetDirectory).Select(Path.GetFileName).ToList();
                // Разделяем строку с именами файлов

                List<string> desiredFileNames = photos.Split('|').ToList();
                for (int j = 0; j < desiredFileNames.Count; j++)
                {
                    desiredFileNames[j] = desiredFileNames[j].Split("/")[^1];
                }
                // Находим и удаляем файлы, которых нет в строке
                var filesToRemove = existingFiles.Except(desiredFileNames);
                foreach (var fileToRemove in filesToRemove)
                {
                    var filePathToRemove = Path.Combine(targetDirectory, fileToRemove);
                    if (System.IO.File.Exists(filePathToRemove))
                    {
                        System.IO.File.Delete(filePathToRemove);
                        Console.WriteLine($"File '{fileToRemove}' removed.");
                    }
                }
                if (model.UserPhotos.Count > 0)
                {
                    photos += "|";
                }
                for (int j = 0; j < model.UserPhotos.Count; j++)
                {
                    if (model.UserPhotos[j].Length > 0)
                    {
                        // Генерируем уникальное имя файла
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.UserPhotos[j].FileName);
                        if (j == model.UserPhotos.Count - 1)
                        {
                            photos = photos + $"/Photos/{i}/" + fileName;
                        }
                        else
                        {
                            photos = photos + $"/Photos/{i}/" + fileName + "|";
                        }
                        // Полный путь к файлу
                        var filePath = Path.Combine(targetDirectory, fileName);

                        // Сохраняем файл на диск
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.UserPhotos[j].CopyToAsync(stream);
                        }
                    }
                }
                Ad ad = repository.Ads.FirstOrDefault(a => a.AdID == model.AdID);
                {
                    ad.Name = model.Name;
                    ad.City = model.City;
                    ad.Description = model.Description;
                    ad.Photos = photos;
                    ad.Price = model.Price;
                    ad.Category = repository.Categories.FirstOrDefault(c => c.Name == model.Category).Name;
                    ad.CreatedDate = DateTime.Now;
                };
                repository.SaveAd(ad);
            }
            return Redirect("/Ads/MyAds/Page1");
        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteAd(long? AdId)
        {
            if (User.Identity.Name == repository.Ads.FirstOrDefault(a => a.AdID == AdId).Owner || User.Identity.Name == "Admin")
            {
                string targetDirectory = Path.Combine(webHostEnvironment.WebRootPath, $"Photos/{AdId}/");
                if (Directory.Exists(targetDirectory))
                {
                    Directory.Delete(targetDirectory, true);
                }
                repository.DeleteAd(repository.Ads.FirstOrDefault(a => a.AdID == AdId));
                repository.SaveChanges();
            }

            return Redirect("/");
        }
    }

}
