namespace CourseProject.Models.ViewModels
{
    public class SignUpModel
    {
        public required string Phone { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }

    }
}