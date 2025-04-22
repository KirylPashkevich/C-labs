using FluentValidation;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Repository;
using Kurs.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IValidator<GroupForCreationDto> _validator;
        public GroupController(IGroupRepository groupRepository, IValidator<GroupForCreationDto> groupForCreationValidator)
        {
            _groupRepository = groupRepository;
            _validator = groupForCreationValidator;
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
        [HttpPost]
        public IActionResult CreateGroup(int courseId, [FromBody] GroupForCreationDto group)
        {
            if (group is null) return BadRequest("GroupForCreationDto object is null");

            // Валидация GroupForCreationDto
            var validationResult = _validator.Validate(group);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ValidationProblem(ModelState);
            }

            var grupToReturn = _groupRepository.CreateGroup(courseId, group, false);

            return CreatedAtRoute("GetGroup", new { id = grupToReturn.GroupId }, grupToReturn);
        }
        [HttpDelete]
        public NoContentResult DeleteGroup(int id)
        {
            _groupRepository.DeleteGroup(id, false);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateGroup(int groupId, int courseId, [FromBody] GroupForUpdateDto groupForUpdate)
        {
            if (groupForUpdate is null) return BadRequest("GroupForUpdateDto object is null");
            _groupRepository.UpdateGroup(groupId, courseId, groupForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}