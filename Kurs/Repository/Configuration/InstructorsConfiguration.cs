using Kurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Kurs.Repository.Configuration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasData(
                new Instructor
                {
                    InstructorID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    MiddleName = "Michael",
                    DateOfBirth = new DateTime(1980, 05, 15),
                    Address = "123 Main St",
                    Phone = "555-123-4567",
                    Email = "john.doe@example.com",
                    ExperienceYears = 10
                },
                new Instructor
                {
                    InstructorID = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    MiddleName = "Elizabeth",
                    DateOfBirth = new DateTime(1985, 10, 20),
                    Address = "456 Oak Ave",
                    Phone = "555-987-6543",
                    Email = "jane.smith@example.com",
                    ExperienceYears = 5
                }
            );
        }
    }
}