using Microsoft.EntityFrameworkCore;
using System;

namespace CourseProject.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            PlatformDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<PlatformDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Ads.Any())
            {
                context.Ads.AddRange(
                    new Ad
                    {
                        Owner = "John Doe",
                        OwnerPhone = "123-456-7890",
                        City = "New York",
                        Name = "Smartphone",
                        Description = "A modern smartphone with advanced features",
                        Price = 599.99m,
                        Category = "Electronics",
                        Photos = "/Photos/smartphone.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Jane Doe",
                        OwnerPhone = "987-654-3210",
                        City = "Los Angeles",
                        Name = "Mountain Bike",
                        Description = "A sturdy mountain bike for off-road adventures",
                        Price = 799.99m,
                        Category = "Sports & Outdoors",
                        Photos = "/Photos/mountain_bike.jpg",
                        CreatedDate = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
