using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "User email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User password is required")]
        public string Password { get; set; }
    }
}
