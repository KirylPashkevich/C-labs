using Kurs.Contracts;
using Kurs.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/instructors")]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
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
    }
}