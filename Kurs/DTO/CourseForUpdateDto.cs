namespace Kurs.DTO
{
    public class CourseForUpdateDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int DurationHours { get; init; }
    }
}
