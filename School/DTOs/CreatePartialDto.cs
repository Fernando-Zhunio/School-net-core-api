using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class CreatePartialDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
