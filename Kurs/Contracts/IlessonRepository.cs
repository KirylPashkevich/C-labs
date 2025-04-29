using Kurs.DTO;

namespace Kurs.Contracts
{
    public interface ILessonRepository
    {
        IEnumerable<LessonDto> GetAllLessons(bool trackChanges);
        LessonDto GetLesson(int id, bool trackChanges);
    }
}