using Microsoft.EntityFrameworkCore;
using Kurs.Models;
using Kurs.Repository.Configuration;
namespace Kurs.Repository
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
        }
    }
}
