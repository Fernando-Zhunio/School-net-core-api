using School.Tools;

namespace School.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string surname { get; set; }
        public TypeDoc TypeDoc { get; set; }
        public string NumberDoc { get; set; }
        public string Email { get; set; }

    }
}
