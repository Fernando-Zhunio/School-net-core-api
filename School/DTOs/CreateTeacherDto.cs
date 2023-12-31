﻿using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class CreateTeacherDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public int TypeDoc { get; set; }
        [Required]
        public string NumberDoc { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
