using AutoMapper;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Models;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public LessonRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<LessonDto> GetAllLessons(bool trackChanges) =>
            _mapper.Map<IEnumerable<LessonDto>>(_context.Lessons);

        public LessonDto GetLesson(int id, bool trackChanges)
        {
            var lesson = _context.Lessons.FirstOrDefault(l => l.LessonID == id);
            if (lesson == null)
                throw new InvalidOperationException($"Lesson with id: {id} doesn't exist.");
            return _mapper.Map<LessonDto>(lesson);
        }
    }
}