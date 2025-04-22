using Kurs.Models;
using Kurs.DTO;
namespace Kurs.Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<CourseDto> GetAllCourses(bool trackChanges);
        CourseDto GetCourse(int id, bool trackChanges);
        CourseDto CreateCourse(CourseForCreationDto course);
        void DeleteCourse(int course, bool trackChanges);
        void UpdateCourse(int course, CourseForUpdateDto courseForUpdate, bool trackChanges);
    }
}
