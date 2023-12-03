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

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
