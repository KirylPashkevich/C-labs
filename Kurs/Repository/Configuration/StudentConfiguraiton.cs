using Kurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Kurs.Repository.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student
                {
                    StudentID = 1,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    MiddleName = "Marie",
                    DateOfBirth = new DateTime(2000, 07, 10),
                    Address = "789 Pine Ln",
                    Phone = "555-555-1212",
                    Email = "alice.johnson@example.com",
                    GroupID = 1 
                },
                new Student
                {
                    StudentID = 2,
                    FirstName = "Bob",
                    LastName = "Williams",
                    MiddleName = "Robert",
                    DateOfBirth = new DateTime(1999, 12, 01),
                    Address = "101 Oak St",
                    Phone = "555-555-3434",
                    Email = "bob.williams@example.com",
                    GroupID = 2 
                }
            );
        }
    }
}