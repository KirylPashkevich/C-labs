namespace Kurs.DTO
{
    public class CourseForCreationDto
    {


        public string Title { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int DurationHours { get; init; }
    }
}
