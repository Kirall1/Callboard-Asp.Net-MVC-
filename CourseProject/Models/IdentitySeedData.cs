using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace CourseProject.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();


            RoleManager<IdentityRole> roleManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));

            IdentityUser? user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                user.PhoneNumber = "375291471844";
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, "Admin");
            }
            user = await userManager.FindByNameAsync("Kir");
            if (user == null)
            {
                user = new IdentityUser("Kir");
                user.PhoneNumber = "5551234555";
                await userManager.CreateAsync(user, "qwertY!@3");
                await userManager.AddToRoleAsync(user, "User");
            }
            user = await userManager.FindByNameAsync("Alexi");
            if (user == null)
            {
                user = new IdentityUser("Alexi");
                user.PhoneNumber = "1111111111";
                await userManager.CreateAsync(user, "123qweR$");
                await userManager.AddToRoleAsync(user, "User");
            }
            user = await userManager.FindByNameAsync("Max");
            if (user == null)
            {
                user = new IdentityUser("Max");
                user.PhoneNumber = "9876543210";
                await userManager.CreateAsync(user, "FuckUM4x)");
                await userManager.AddToRoleAsync(user, "User");
            }
            user = await userManager.FindByNameAsync("Pikagem");
            if (user == null)
            {
                user = new IdentityUser("Pikagem");
                user.PhoneNumber = "1212121212";
                await userManager.CreateAsync(user, "PikPik1!)");
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
