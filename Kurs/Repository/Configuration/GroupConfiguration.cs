using Kurs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Kurs.Repository.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasData(
                new Group
                {
                    GroupID = 1,
                    CourseID = 1, // Предполагается, что у вас есть Course с CourseID = 1
                    Name = "Group A",
                    StartDate = new DateTime(2025, 04, 01),
                    EndDate = new DateTime(2025, 06, 30),
                    MaxStudents = 20
                },
                new Group
                {
                    GroupID = 2,
                    CourseID = 2, // Предполагается, что у вас есть Course с CourseID = 2
                    Name = "Group B",
                    StartDate = new DateTime(2025, 05, 01),
                    EndDate = new DateTime(2025, 07, 31),
                    MaxStudents = 15
                }
            );
        }
    }
}