using AutoMapper;
using Kurs.Contracts;
using Kurs.Models;
using Kurs.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Kurs.Models.Extensions;

namespace Kurs.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly IMapper _mapper;

        public StudentRepository(RepositoryContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
        {
            var students = FindAll(trackChanges).OrderBy(s => s.StudentID).ToList();

            // Используем AutoMapper для преобразования IEnumerable<Student> в IEnumerable<StudentDto>
            var studentsDto = _mapper.Map<List<StudentDto>>(students);

            return studentsDto;
        }

        public StudentDto GetStudent(int id, bool trackChanges)
        {
            var student = FindByCondition(s => s.StudentID.Equals(id), trackChanges)
                  .SingleOrDefault();

            if (student == null)
            {
                throw new StudentNotFoundException(id); 
            }

            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }
        public StudentDto CreateStudent(int groupId, StudentForCreationDto studentForCreationDto, bool trackChanges)
        {
            var groupToCheck = _context.Set<Models.Group>()
                .Where(g => g.GroupID.Equals(groupId))
                .AsNoTracking()
                .SingleOrDefault();
            if (groupToCheck is null)
                throw new GroupNotFoundException(groupId);
            var studentEntity = _mapper.Map<Student>(studentForCreationDto);
            studentEntity.GroupID = groupId;
            Create(studentEntity);
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return studentToReturn;
        }
        public void DeleteStudent(int studentId, bool trackChanges)
        {
            var student = _context.Set<Student>()
                .Where(g => g.StudentID.Equals(studentId))
                .AsNoTracking()
                .FirstOrDefault();

            if (student is null) throw new StudentNotFoundException(studentId);

            Delete(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(int studentId, StudentForUpdateDto studentForUpdate, bool trackChanges)
        {
            var student = _context.Set<Student>()
                .Where(g => g.StudentID.Equals(studentId))
                .AsNoTracking()
                .SingleOrDefault();

            if (student is null) throw new StudentNotFoundException(studentId);

            var studentEntity = FindByCondition(gt => gt.StudentID.Equals(studentId), trackChanges).SingleOrDefault();
            if (studentEntity is null) throw new Exception();
            _mapper.Map(studentForUpdate, studentEntity);
            _context.SaveChanges();
        }
    }
}