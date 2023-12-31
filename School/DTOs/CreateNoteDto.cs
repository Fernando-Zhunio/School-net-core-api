﻿using School.Models;
using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class CreateNoteDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int PeriodId { get; set; }
        [Required]
        public int PartialId { get; set; }
        [Required]
        public double note { get; set; }
    }
}
