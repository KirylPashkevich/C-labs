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

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
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
    }
}