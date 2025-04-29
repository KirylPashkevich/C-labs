using AutoMapper;
using Kurs.Contracts;
using Kurs.DTO;
using Kurs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kurs.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CourseDto> GetAllCourses(bool trackChanges) =>
            _mapper.Map<IEnumerable<CourseDto>>(_context.Courses);

        public CourseDto GetCourse(int id, bool trackChanges)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseID == id);
            if (course == null)
                throw new InvalidOperationException($"Course with id: {id} doesn't exist.");
            return _mapper.Map<CourseDto>(course);
        }
    }
}
