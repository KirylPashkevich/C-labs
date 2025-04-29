using Kurs.DTO;

namespace Kurs.Contracts
{
    public interface IInstructorRepository
    {
        IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges);
        InstructorDto GetInstructor(int id, bool trackChanges);
    }
}