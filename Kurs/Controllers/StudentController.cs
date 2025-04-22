using FluentValidation;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IValidator<StudentForCreationDto> _validator;

        public StudentController(IStudentRepository studentRepository, IValidator<StudentForCreationDto> validator)
        {
            _studentRepository = studentRepository;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents(trackChanges: false);
            return Ok(students);
        }

        [HttpGet("{id:int}", Name = "GetStudent")] 
        public IActionResult GetStudent(int id)
        {
            var student = _studentRepository.GetStudent(id, trackChanges: false);
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Createstudent(int groupId, [FromBody] StudentForCreationDto studentForCreationDto)
        {
            if (studentForCreationDto is null)
                return BadRequest("StudentForCreationDto object is null");

            // Валидация StudentForCreationDto
            var validationResult = _validator.Validate(studentForCreationDto);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ValidationProblem(ModelState);
            }

            var studentToReturn = _studentRepository.CreateStudent(groupId, studentForCreationDto, false);
            return CreatedAtRoute("GetStudent", new { id = studentToReturn.id }, studentToReturn);
        }

        [HttpDelete]
        public NoContentResult DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id, false);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateStudent(int studentId, [FromBody] StudentForUpdateDto studentForUpdate)
        {
            if (studentForUpdate is null) return BadRequest("StudentForUpdateDto object is null");
            _studentRepository.UpdateStudent(studentId, studentForUpdate, trackChanges: false);
            return NoContent();
        }
    }
}