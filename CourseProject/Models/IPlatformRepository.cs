namespace CourseProject.Models
{
    public interface IPlatformRepository
    {
        IQueryable<Ad> Ads { get; }
    }
}
