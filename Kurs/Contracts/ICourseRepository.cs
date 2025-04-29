using Kurs.Models;
using Kurs.DTO;
namespace Kurs.Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<CourseDto> GetAllCourses(bool trackChanges);
        CourseDto GetCourse(int id, bool trackChanges);
    }
}
