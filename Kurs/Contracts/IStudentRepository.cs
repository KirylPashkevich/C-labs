using Kurs.Models;
using Kurs.DTO;
namespace Kurs.Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
        StudentDto GetStudent(int id, bool trackChanges);
        StudentDto CreateStudent(int groupId,StudentForCreationDto studentForCreationDto, bool trackChanges);
        void DeleteStudent(int studentId, bool trackChanges);
        void UpdateStudent(int studentId, StudentForUpdateDto studentForUpdate, bool trackChanges);
    }
}