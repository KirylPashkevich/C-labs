namespace Kurs.Models.Extensions
{
    public sealed class GroupNotFoundException:NotFoundException
    {
        public GroupNotFoundException(int groupId): base($"The group with id: {groupId} doesnt exist in the database")
        {

        }
    }
}
