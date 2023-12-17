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

            if (!context.Categories.Any())
            {
                //add Electronics, Sports and Furniture categories
                context.Categories.AddRange(
                    new Category { Name = "Electronics" },
                    new Category { Name = "Sports" },
                    new Category { Name = "Furniture" }
                );
                context.SaveChanges();
            }

            if (!context.Ads.Any())
            {
                context.Ads.AddRange(
                    new Ad
                    {
                        Owner = "Alexi",
                        OwnerPhone = "1111111111",
                        City = "New York",
                        Name = "Smartphone",
                        Description = "A modern smartphone with advanced features",
                        Price = 599.99m,
                        Category = "Electronics",
                        Photos = "/Photos/1/1.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Max",
                        OwnerPhone = "9876543210",
                        City = "Los Angeles",
                        Name = "Mountain Bike",
                        Description = "A sturdy mountain bike for off-road adventures",
                        Price = 799.99m,
                        Category = "Sports",
                        Photos = "/Photos/2/1.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Pikagem",
                        OwnerPhone = "1212121212",
                        City = "Chicago",
                        Name = "Laptop",
                        Description = "A powerful laptop with advanced features",
                        Price = 1299.99m,
                        Category = "Electronics",
                        Photos = "/Photos/3/1.jpg|/Photos/3/2.jpg|/Photos/3/1.jpg|/Photos/3/3.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Kir",
                        OwnerPhone = "5551234555",
                        City = "New York",
                        Name = "Coffee Table",
                        Description = "Rustic wood coffee table",
                        Price = 199.99m,
                        Category = "Furniture",
                        Photos = "/Photos/4/1.jpg",
                        CreatedDate = DateTime.Now
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
