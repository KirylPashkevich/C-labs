namespace Kurs.DTO
{
    public class GroupForUpdateDto
    {
        public int GroupID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxStudents { get; set; }
    }
}
