using CourseProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlatformDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:AdvertisementPlatformConnection"]);
});

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:IdentityConnection"]));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddUserValidator<CustomUserValidator<IdentityUser>>();


builder.Services.AddScoped<IPlatformRepository, EFPlatformRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute("signup", "Account/SignUp", new { Controller = "Account", action = "SignUp" });
app.MapControllerRoute("signin", "Account/SignIn", new { Controller = "Account", action = "SignIn" });


app.MapControllerRoute("catpage", "{category}/Page{adPage:int}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{adPage:int}", new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination", "Ads/Page{adPage}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("userads", "Ads/MyAds/Page{adPage:int}", new { Controller = "Home", action = "UserAds", productPage = 1 });
app.MapControllerRoute("error", "Error/Error={errorMessage}", new { Controller = "Home", action = "Error" });


app.MapControllerRoute("adpage", "Ad/{adId:int}", new { Controller = "Ad", action = "Index" });
app.MapControllerRoute("adpageedit", "EditAd/{adId:int}", new { Controller = "Ad", action = "AdEditor" });
app.MapControllerRoute("deletead", "DeleteAd/{adId:int}", new { Controller = "Ad", action = "DeleteAd" });

app.MapControllerRoute("usersmanagment", "Admin/UsersManager", new { Controller = "Admin", action = "UsersManager" });
app.MapControllerRoute("deleteuser", "Admin/DeleteUser/{name}", new { Controller = "Admin", action = "DeleteUser" });



app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
