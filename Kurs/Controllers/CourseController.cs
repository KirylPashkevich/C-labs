using FluentValidation;
using Kurs.Contracts;
using Kurs.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IValidator<CourseForCreationDto> _validator;

        public CourseController(ICourseRepository courseRepository, IValidator<CourseForCreationDto> validator)
        {
            _courseRepository = courseRepository;
            _validator = validator;
        }

        [HttpGet] 
        public IActionResult GetAllCourses()
        {
            var courses = _courseRepository.GetAllCourses(trackChanges: false);
            return Ok(courses);
        }

        [HttpGet("{id:int}", Name = "GetCourse")]
        public IActionResult GetCourse(int id)
        {
            var course = _courseRepository.GetCourse(id, trackChanges: false);
            return Ok(course);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CourseForCreationDto courseForCreationDto)
        {
            if (courseForCreationDto is null)
            {
                return BadRequest("CourseForCreationDto object is null");
            }

            // Валидация с помощью FluentValidation
            var validationResult = _validator.Validate(courseForCreationDto);

            if (!validationResult.IsValid)
            {
                // Возвращаем ошибки валидации в формате BadRequest
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ValidationProblem(ModelState); // Используем ValidationProblem для более стандартизированного ответа
            }

            var createdCourse = _courseRepository.CreateCourse(courseForCreationDto);

            return CreatedAtRoute("GetCourse", new { id = createdCourse.CourseID }, createdCourse);
        }

        [HttpDelete("{id:int}")]
        public NoContentResult DeleteCourse(int id)
        {
            _courseRepository.DeleteCourse(id, false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseForUpdateDto courseForUpdate)
        {
            if (courseForUpdate is null) return BadRequest("CourseForUpdate object is null");

            _courseRepository.UpdateCourse(id, courseForUpdate, trackChanges: true);

            return NoContent();
        }
    }
}