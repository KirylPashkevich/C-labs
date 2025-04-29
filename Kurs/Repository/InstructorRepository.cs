using AutoMapper;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Models;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public InstructorRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges) =>
            _mapper.Map<IEnumerable<InstructorDto>>(_context.Instructors);

        public InstructorDto GetInstructor(int id, bool trackChanges)
        {
            var instructor = _context.Instructors.FirstOrDefault(i => i.InstructorID == id);
            if (instructor == null)
                throw new InvalidOperationException($"Instructor with id: {id} doesn't exist.");
            return _mapper.Map<InstructorDto>(instructor);
        }
    }
}