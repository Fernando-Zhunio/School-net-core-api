namespace School.Models
{
    public class Tuition
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PeriodId { get; set; }
        public Student Student { get; set; }
        public Period Period { get; set; }
    }
}
