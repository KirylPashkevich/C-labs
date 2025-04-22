using Kurs.Models;
using Kurs.DTO;
namespace Kurs.Contracts
{
    public interface IGroupRepository
    {
        IEnumerable<GroupDto> GetAllGroups(bool trackChanges);
        GroupDto GetGroup(int id, bool trackChanges);
        GroupDto CreateGroup(int courseId, GroupForCreationDto group, bool trackChanges);
        void DeleteGroup(int groupId, bool trackChanges);
        void UpdateGroup(int groupid,int courseId, GroupForUpdateDto groupForUpdate, bool trackChanges);
    }
}
