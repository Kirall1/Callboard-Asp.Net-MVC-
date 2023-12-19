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
        public IQueryable<Category> Categories => context.Categories;

        public void CreateAd(Ad a)
        {
            context.Ads.Add(a);
            context.SaveChanges();
        }
        public void DeleteAd(Ad a)
        {
            context.Ads.Remove(a);
        }
        public void SaveAd(Ad a)
        {
            context.SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
