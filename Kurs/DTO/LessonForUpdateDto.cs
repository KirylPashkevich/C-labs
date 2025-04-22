namespace Kurs.DTO
{
    public class LessonForUpdateDto
    {
        public int LessonId { get; set; }
        public int GroupID { get; set; }
        public int InstructorID { get; set; }
        public DateTime DateTime { get; set; }
        public string LessonType { get; set; }

        public string Description { get; set; }
    }
}
