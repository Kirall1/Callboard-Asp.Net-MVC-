using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class Ad
    {
        public long? AdID { get; set; }

        public string Owner { get; set; } = String.Empty;

        public string OwnerPhone { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; } = String.Empty;


        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; } = String.Empty;
        

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; } = String.Empty;
        

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; } = String.Empty;



        [Required(ErrorMessage = "Please load at least one photo")]
        public string Photos { get; set; } = String.Empty;


        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
