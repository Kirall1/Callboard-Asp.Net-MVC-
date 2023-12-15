using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string? Name { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;

        public string Role { get; set; } = "User";
    }
}