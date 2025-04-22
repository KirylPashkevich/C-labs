using FluentValidation;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/instructors")]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IValidator<InstructorForCreationDto> _validator;

        public InstructorController(IInstructorRepository instructorRepository, IValidator<InstructorForCreationDto> validator)
        {
            _instructorRepository = instructorRepository;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetAllInstructors()
        {
            var instructors = _instructorRepository.GetAllInstructors(trackChanges: false);
            return Ok(instructors);
        }

        [HttpGet("{id:int}", Name = "GetInstructor")]
        public IActionResult GetInstructor(int id)
        {
            var instructor = _instructorRepository.GetInstructor(id, trackChanges: false);
            return Ok(instructor);
        }
        [HttpPost]
        public IActionResult CreateInstructor([FromBody] InstructorForCreationDto instructorForCreationDto)
        {
            if (instructorForCreationDto is null)
                return BadRequest("InstructorForCreationDto object is null");

            // Валидация InstructorForCreationDto
            var validationResult = _validator.Validate(instructorForCreationDto);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ValidationProblem(ModelState);
            }

            var createdInstructor = _instructorRepository.CreateInstuctor(instructorForCreationDto);
            return CreatedAtRoute("GetInstructor", new { id = createdInstructor.id }, createdInstructor);
        }

        [HttpDelete]
        public NoContentResult DeleteInstructor(int instructorId)
        {
            _instructorRepository.DeleteInstructor(instructorId, false);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateInstructor(int instructorId, [FromBody] InstructorForUpdateDto instructorForUpdate)
        {
            if (instructorForUpdate is null) return BadRequest("InstructorForUpdate object is null");
            _instructorRepository.UpdateInstructor(instructorId, instructorForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}