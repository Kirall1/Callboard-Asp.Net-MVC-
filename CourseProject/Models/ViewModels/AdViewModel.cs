namespace CourseProject.Models.ViewModels
{
    public class AdViewModel
    {
        public long? AdID { get; set; } = 0;
        public string? Name { get; set; } = string.Empty;
        public decimal? Price { get; set; } = 0;
        public string? City { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Photos { get; set; } = String.Empty;
        public IQueryable<string?>? Categories { get; set; } = null;
        public string? Category { get; set; } = string.Empty;
        public IFormFileCollection UserPhotos { get; set; } = new FormFileCollection();

    }
}