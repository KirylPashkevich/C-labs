using Kurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Kurs.Repository.Configuration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasData(
                new Lesson
                {
                    LessonID = 1,
                    GroupID = 1, // Предполагается, что у вас есть Group с GroupID = 1
                    InstructorID = 1, // Предполагается, что у вас есть Instructor с InstructorID = 1
                    DateTime = new DateTime(2025, 04, 05, 10, 0, 0), // 2025-04-05 10:00:00
                    LessonType = "Lecture",
                    Description = "Introduction to C# basics"
                },
                new Lesson
                {
                    LessonID = 2,
                    GroupID = 2, // Предполагается, что у вас есть Group с GroupID = 2
                    InstructorID = 2, // Предполагается, что у вас есть Instructor с InstructorID = 2
                    DateTime = new DateTime(2025, 05, 08, 14, 0, 0), // 2025-05-08 14:00:00
                    LessonType = "Lab",
                    Description = "Hands-on practice with advanced C# features"
                }
            );
        }
    }
}