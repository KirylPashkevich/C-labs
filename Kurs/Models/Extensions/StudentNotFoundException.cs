namespace Kurs.Models.Extensions
{
    public sealed class StudentNotFoundException: NotFoundException
    {
        public StudentNotFoundException(int studentId) : base($"The student with id: {studentId} doesnt exist in the database")
        {

        }
    }
}
