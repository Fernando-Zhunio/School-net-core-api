using School.Tools;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public TypeDoc TypeDoc { get; set; }
        [Required]
        public string NumberDoc { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
