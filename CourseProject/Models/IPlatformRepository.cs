namespace CourseProject.Models
{
    public interface IPlatformRepository
    {
        IQueryable<Ad> Ads { get; }
        IQueryable<Category> Categories { get; }

        void SaveAd(Ad a);
        void CreateAd(Ad a);
        void DeleteAd(Ad a);
        void SaveChanges();
    }
}
