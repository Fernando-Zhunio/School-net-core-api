using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "User email is required")]
        public string Email { get; set;}
        [Required(ErrorMessage = "User email is required")]
        public string Password { get; set; }

    }
}
