using Kurs.Models;
using Kurs.DTO;
namespace Kurs.Contracts
{
    public interface IGroupRepository
    {
        IEnumerable<GroupDto> GetAllGroups(bool trackChanges);
        GroupDto GetGroup(int id, bool trackChanges);
    }
}
