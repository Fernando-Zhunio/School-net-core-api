using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System.Reflection;

namespace School
{
    public class DatabaseContext: IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Models.Parallel> Parallels { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Partial> Partials { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<School.Models.Tuition> Tuition { get; set; } = default!;
    }
}
