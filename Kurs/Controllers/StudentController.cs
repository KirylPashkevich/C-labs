using Kurs.Contracts;
using Kurs.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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
    }
}