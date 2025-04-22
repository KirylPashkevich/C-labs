using Kurs.Contracts;
using Kurs.Models;
using Kurs.DTO;
using AutoMapper;
using Kurs.Models.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Repository
{
    public class CourseRepository: RepositoryBase<Course>, ICourseRepository
    {
        private readonly IMapper _mapper;
        public CourseRepository(RepositoryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<CourseDto> GetAllCourses(bool trackChanges)
        {
            var courses = FindAll(trackChanges)
                 .OrderBy(g => g.CourseID)
                 .ToList();
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
            //var coursesDto = courses.Select(g =>
            //new CourseDto(g.CourseID, g.Title,g.Price)).ToList();

            return coursesDto;
        }
        public CourseDto GetCourse(int id, bool trackChanges)
        {
            var course = FindByCondition(g => g.CourseID.Equals(id), trackChanges)
                 .SingleOrDefault();
            if (course is null) throw new CourseNotFoundException(id);
            var courseDto = _mapper.Map<CourseDto>(course);

            //var courseDto = new CourseDto(course.CourseID, course.Title, course.Price);

            return courseDto;
        }
        public CourseDto CreateCourse(CourseForCreationDto courseDto)
        {
            var courseEntity = _mapper.Map<Course>(courseDto);
            Create(courseEntity);
            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

            return courseToReturn;
        }
        public void DeleteCourse(int courseId, bool trackChanges)
        {
            var course = _context.Set<Course>()
                .Where(g => g.CourseID.Equals(courseId))
                .AsNoTracking()
                .SingleOrDefault();

            if (course is null) throw new CourseNotFoundException(courseId);

            Delete(course);
            _context.SaveChanges();
        }
        public void UpdateCourse(int courseId, CourseForUpdateDto courseForUpdate, bool trackChanges)
        {
            var course = _context.Set<Course>()
                .Where(g => g.CourseID.Equals(courseId))
                .AsNoTracking()
                .SingleOrDefault();
            if (course is null) throw new CourseNotFoundException(courseId);

            var courseEntity = FindByCondition(gt => gt.CourseID.Equals(courseId), trackChanges).SingleOrDefault();

            if (courseEntity is null) throw new CourseNotFoundException(courseId);

            _mapper.Map(courseForUpdate, courseEntity);
            _context.SaveChanges();
        }
    }
}
