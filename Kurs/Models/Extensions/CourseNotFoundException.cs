namespace Kurs.Models.Extensions
{
    public sealed class CourseNotFoundException: NotFoundException
    {
        public CourseNotFoundException(int courseId)
        :base($"The course with id: {courseId} doesnt exist in the database")
            {
          
        }
    }
}
