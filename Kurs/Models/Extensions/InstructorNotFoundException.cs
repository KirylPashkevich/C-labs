namespace Kurs.Models.Extensions
{
    public sealed class InstructorNotFoundException:NotFoundException
    {
       public InstructorNotFoundException(int instructorId) : base($"The group with id: {instructorId} doesnt exist in the database")
        {

        }
    }
}
