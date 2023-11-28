using School.Tools;

namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public TypeDoc TypeDoc { get; set; }
        public string NumberDoc { get; set; }
        public string Email { get; set; }
        public Tuition Tuition { get; set; }
    }
}
