namespace School.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HashSet<Parallel> parallels { get; set; } = new HashSet<Parallel>();
    }
}
