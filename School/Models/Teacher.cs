﻿using School.Tools;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public int TypeDoc { get; set; }
        [Required]
        public string NumberDoc { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
