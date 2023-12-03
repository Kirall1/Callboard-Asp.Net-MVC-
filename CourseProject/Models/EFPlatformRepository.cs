namespace CourseProject.Models
{
    public class EFPlatformRepository : IPlatformRepository
    {
        private PlatformDbContext context;

        public EFPlatformRepository(PlatformDbContext context) 
        {
            this.context = context;
        }

        public IQueryable<Ad> Ads => context.Ads;
    }
}
