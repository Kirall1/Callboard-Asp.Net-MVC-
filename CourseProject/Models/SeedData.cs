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
                        Photos = "/Photos/3/1.jpg|/Photos/3/2.jpg|/Photos/3/3.jpg",
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
                    },
                    new Ad
                    {
                        Owner = "Alexi",
                        OwnerPhone = "1111111111",
                        City = "New York",
                        Name = "Keyboard DPO 87 Fuji",
                        Description = "Best entry level mechanical keyboard to experience premium custom typing with pre-lubed switches.",
                        Price = 399.99m,
                        Category = "Electronics",
                        Photos = "/Photos/5/1.jpg|/Photos/5/2.jpg|/Photos/5/3.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Pikagem",
                        OwnerPhone = "1212121212",
                        City = "Chicago",
                        Name = "Headsets HyperX Cloud Alpha",
                        Description = "Over 300 hours of battery, DTS Headphone:X Spatial Audio, HyperX Dual Chamber Drivers, Compatible with PC.",
                        Price = 279.99m,
                        Category = "Electronics",
                        Photos = "/Photos/6/1.jpg|/Photos/6/2.jpg|/Photos/6/3.jpg|/Photos/6/4.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Max",
                        OwnerPhone = "9876543210",
                        City = "Los Angeles",
                        Name = "Electric kettle L'Ornay LA-4612",
                        Description = "Electric kettle is designed for heating or boiling drinking water. The built-in controller will automatically turn off the kettle when the water reaches boiling point.",
                        Price = 14.99m,
                        Category = "Furniture",
                        Photos = "/Photos/7/1.jpg|/Photos/7/2.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Kir",
                        OwnerPhone = "5551234555",
                        City = "New York",
                        Name = "Knife Samura Bamboo SBA-0021",
                        Description = "The utility knife is one of the most versatile tools available. It is suitable for salads, cutting soup ingredients and preparing sandwiches.",
                        Price = 28.99m,
                        Category = "Furniture",
                        Photos = "/Photos/8/1.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Max",
                        OwnerPhone = "9876543210",
                        City = "Los Angeles",
                        Name = "Men's swimming trunks",
                        Description = "Men's swim shorts for swimming in the pool and beach vacation with contrast trim in the waistband and pocket, in line with fashion trends.",
                        Price = 14.59m,
                        Category = "Sports",
                        Photos = "/Photos/9/1.jpg",
                        CreatedDate = DateTime.Now
                    },
                    new Ad
                    {
                        Owner = "Pikagem",
                        OwnerPhone = "1212121212",
                        City = "Chicago",
                        Name = "SSD Samsung 980 1TB MZ-V8V1T0BW",
                        Description = "1 TB memory size, PCI Express 3.0 4x, reading speed 3500 MB/sec.",
                        Price = 229.99m,
                        Category = "Electronics",
                        Photos = "/Photos/10/1.jpg|/Photos/10/2.jpg",
                        CreatedDate = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
