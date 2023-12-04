using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlatformDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:AdvertisementPlatformConnection"]);
});

builder.Services.AddScoped<IPlatformRepository, EFPlatformRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute("catpage", "{category}/Page{adPage:int}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{adPage:int}", new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination", "Ads/Page{adPage}", new { Controller = "Home", action = "Index" });


app.MapControllerRoute("adpage", "Ad/{adId:int}", new { Controller = "Ad", action = "Index" });

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
