using Kurs.Contracts;
using Kurs.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
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
    }
}