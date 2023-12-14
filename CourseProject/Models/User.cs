using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string? Name { get; set; } = String.Empty;


        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; } = String.Empty;


        [Required(ErrorMessage = "Please enter a name")]
        public string Phone { get; set; } = String.Empty;
    }
}