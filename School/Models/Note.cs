namespace School.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int PeridoId { get; set; }
        public double note {  get; set; }
        public Period Period { get; set; }
        public Partial Partial {  get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
