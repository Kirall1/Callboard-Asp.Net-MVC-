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
                        Category = "Sports",
                        Photos = "/Photos/mountain_bike.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Bob Smith",
                        OwnerPhone = "000000000000",
                        City = "Chicago",
                        Name = "Laptop",
                        Description = "A powerful laptop with advanced features",
                        Price = 1299.99m,
                        Category = "Electronics",
                        Photos = "/Photos/laptop.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Sally Johnson",
                        OwnerPhone = "555-1234",
                        City = "New York",
                        Name = "Coffee Table",
                        Description = "Rustic wood coffee table",
                        Price = 199.99m,
                        Category = "Furniture",
                        Photos = "/Photos/coffeetable.jpg",
                        CreatedDate = DateTime.Now
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
