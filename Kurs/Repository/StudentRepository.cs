using AutoMapper;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Models;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<StudentDto> GetAllStudents(bool trackChanges) =>
            _mapper.Map<IEnumerable<StudentDto>>(_context.Students);

        public StudentDto GetStudent(int id, bool trackChanges)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
                throw new InvalidOperationException($"Student with id: {id} doesn't exist.");
            return _mapper.Map<StudentDto>(student);
        }
    }
}