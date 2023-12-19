using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options) { }
        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
