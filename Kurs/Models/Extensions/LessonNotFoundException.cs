namespace Kurs.Models.Extensions
{
    public sealed class LessonNotFoundException:NotFoundException
    {
        public LessonNotFoundException(int lessonId) : base($"The lesson with id: {lessonId} doesnt exist in the database")
        {

        }
    }
}
