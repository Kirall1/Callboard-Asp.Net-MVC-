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
        }
    }
}
