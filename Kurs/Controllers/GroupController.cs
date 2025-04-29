using Kurs.Contracts;
using Kurs.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _groupRepository.GetAllGroups(trackChanges: false);
            return Ok(groups);
        }

        [HttpGet("{id:int}", Name ="GetGroup")]
        public IActionResult GetGroup(int id)
        {
            var group = _groupRepository.GetGroup(id, trackChanges: false);
            return Ok(group);
        }
    }
}