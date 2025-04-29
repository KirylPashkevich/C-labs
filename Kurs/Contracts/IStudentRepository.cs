using Kurs.DTO;

namespace Kurs.Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
        StudentDto GetStudent(int id, bool trackChanges);
    }
}