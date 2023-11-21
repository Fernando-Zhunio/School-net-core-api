namespace School.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set;}
    }
}
