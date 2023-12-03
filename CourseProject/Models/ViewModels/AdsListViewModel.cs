namespace CourseProject.Models.ViewModels
{
    public class AdsListViewModel
    {
        public IEnumerable<Ad> Ads { get; set; } = Enumerable.Empty<Ad>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory { get; set; }
    }
}
