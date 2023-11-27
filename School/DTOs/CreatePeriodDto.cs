using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class CreatePeriodDto
    {
        [Required]
        public string name { get; set; }
    }
}
