using School.Models;

namespace School.DTOs
{
    public class CreateSubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
