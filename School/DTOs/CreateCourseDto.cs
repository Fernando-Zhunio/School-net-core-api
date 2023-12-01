using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class CreateCourseDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
