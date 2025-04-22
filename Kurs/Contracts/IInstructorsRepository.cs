using Kurs.Models;
using Kurs.DTO;
namespace Kurs.Contracts
{
    public interface IInstructorRepository
    {
        IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges);
        InstructorDto GetInstructor(int id, bool trackChanges);
        InstructorDto CreateInstuctor(InstructorForCreationDto instructor);
        void DeleteInstructor(int instructorId, bool trachChanges);
        void UpdateInstructor(int instructorId, InstructorForUpdateDto instructorForUpdate, bool trackChanges);
    }
}