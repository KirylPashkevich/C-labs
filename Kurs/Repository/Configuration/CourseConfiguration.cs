using Kurs.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
            new Course
            {
                CourseID = 1,
                Title = "evening enhanced",
                Description = "training on Monday Wednesday Friday evenings.",
                Price = 99.99m,
                DurationHours = 40
            },
            new Course
            {
                CourseID = 2,
                Title = "weekend",
                Description = "training on Saturday and Sunday",
                Price = 199.99m,
                DurationHours = 60
            }
        );
    }
}