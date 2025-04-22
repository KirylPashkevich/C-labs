using Kurs.Models;
using Kurs.DTO;
namespace Kurs.Contracts
{
    public interface ILessonRepository
    {
        IEnumerable<LessonDto> GetAllLessons(bool trackChanges);
        LessonDto GetLesson(int id, bool trackChanges);
        LessonDto CreateLesson(int groupId, int instructorId, LessonForCreationDto lesosn, bool tackChanges);
        void DeleteLesson(int lessonId, bool trackChanges);
        void UpdateLesson(int lessonId,int groupId, int instructorId, LessonForUpdateDto lessonForUpdate, bool trackChanges);
    }
}