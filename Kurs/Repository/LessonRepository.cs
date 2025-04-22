using AutoMapper;
using Kurs.Contracts;
using Kurs.Models;
using Kurs.DTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Kurs.Models.Extensions;

namespace Kurs.Repository
{
    public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        private readonly IMapper _mapper;

        public LessonRepository(RepositoryContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public IEnumerable<LessonDto> GetAllLessons(bool trackChanges)
        {
            var lessons = FindAll(trackChanges).OrderBy(l => l.LessonID).ToList();

            // Используем AutoMapper для преобразования IEnumerable<Lesson> в IEnumerable<LessonDto>
            var lessonsDto = _mapper.Map<List<LessonDto>>(lessons);

            return lessonsDto;
        }

        public LessonDto GetLesson(int id, bool trackChanges)
        {
            var lesson = FindByCondition(l => l.LessonID.Equals(id), trackChanges)
                  .SingleOrDefault();

            if (lesson == null)
            {
                throw new LessonNotFoundException(id); // Или выбросить исключение
            }

            // Используем AutoMapper для преобразования Lesson в LessonDto
            var lessonDto = _mapper.Map<LessonDto>(lesson);

            return lessonDto;
        }
        public LessonDto CreateLesson(int groupId, int instructorId, LessonForCreationDto lesosn, bool tackChanges)
        {
            var groupToCheck = _context.Set<Group>()
                .Where(g => g.GroupID.Equals(groupId))
                .AsNoTracking()
                .SingleOrDefault();

            if (groupToCheck is null) throw new GroupNotFoundException(groupId);

            var instructorToCheck = _context.Set<Instructor>()
                .Where(g => g.InstructorID.Equals(instructorId))
                .AsNoTracking()
                .SingleOrDefault();
            if (instructorToCheck is null) throw new InstructorNotFoundException(instructorId);

            var lessonEntity = _mapper.Map<Lesson>(lesosn);
            lessonEntity.InstructorID = instructorId;
            lessonEntity.GroupID = groupId;
            Create(lessonEntity);

            var lessonToReturn = _mapper.Map<LessonDto>(lessonEntity);

            return lessonToReturn;
        }

        public void DeleteLesson(int lessonId, bool trackChanges)
        {
            var lesson = _context.Set<Lesson>()
                .Where(g => g.LessonID.Equals(lessonId))
                .AsNoTracking()
                .FirstOrDefault();
            if (lesson is null) throw new LessonNotFoundException(lessonId);

            Delete(lesson);
            _context.SaveChanges();
        }
        public void UpdateLesson(int lessonId,int groupId, int instructorid, LessonForUpdateDto lessonForUpdate, bool trackChanges)
        {
            var groupToCheck = _context.Set<Group>()
              .Where(g => g.GroupID.Equals(groupId))
              .AsNoTracking()
              .SingleOrDefault();

            if (groupToCheck is null) throw new GroupNotFoundException(groupId);

            var instructorToCheck = _context.Set<Instructor>()
                .Where(g => g.InstructorID.Equals(instructorid))
                .AsNoTracking()
                .SingleOrDefault();
            if (instructorToCheck is null) throw new InstructorNotFoundException(instructorid);

            var lessonEntity = FindByCondition(gt => gt.LessonID.Equals(lessonId), trackChanges).SingleOrDefault();
            if (lessonEntity is null) throw new Exception();
            _mapper.Map(lessonForUpdate, lessonEntity);
            _context.SaveChanges();
        }
    }
}