using FluentValidation;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Validators;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IValidator<LessonForCreationDto> _validator;

        public LessonController(ILessonRepository lessonRepository, IValidator<LessonForCreationDto> validator)
        {
            _lessonRepository = lessonRepository;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetAllLessons()
        {
            var lessons = _lessonRepository.GetAllLessons(trackChanges: false);
            return Ok(lessons);
        }

        [HttpGet("{id:int}", Name = "GetLesson")]
        public IActionResult GetLesson(int id)
        {
            var lesson = _lessonRepository.GetLesson(id, trackChanges: false);
            return Ok(lesson);
        }
        [HttpPost]
        public IActionResult CreateLesson(int groupId, int instructorId, [FromBody] LessonForCreationDto lesson)
        {
            if (lesson is null) return BadRequest("LessonForCreationDto is null");

            // Валидация LessonForCreationDto
            var validationResult = _validator.Validate(lesson); // Добавьте эту строку

            if (!validationResult.IsValid) // Добавьте эту строку
            {
                foreach (var error in validationResult.Errors) // Добавьте эту строку
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); // Добавьте эту строку
                }
                return ValidationProblem(ModelState); // Добавьте эту строку
            }

            var lessonToReturn = _lessonRepository.CreateLesson(groupId, instructorId, lesson, false);
            return CreatedAtRoute("GetLesson", new { groupId = groupId, id = instructorId }, lessonToReturn);
        }
        [HttpDelete]
        public NoContentResult DeleteLesson(int id)
        {
            _lessonRepository.DeleteLesson(id, false);

            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateLesson(int lessonId, int groupid, int instructorId, [FromBody] LessonForUpdateDto lessonForUpdate)
        {
            if (lessonForUpdate is null) return BadRequest("LessonForUpdateDto object is null");
            _lessonRepository.UpdateLesson(lessonId, groupid, instructorId, lessonForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}