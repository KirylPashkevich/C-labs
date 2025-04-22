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
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
    {
        private readonly IMapper _mapper;

        public InstructorRepository(RepositoryContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges)
        {
            var instructors = FindAll(trackChanges).OrderBy(g => g.InstructorID).ToList();

            // Используем AutoMapper для преобразования IEnumerable<Instructor> в IEnumerable<InstructorDto>
            var instructorsDto = _mapper.Map<List<InstructorDto>>(instructors);

            return instructorsDto;
        }

        public InstructorDto GetInstructor(int id, bool trackChanges)
        {
            var instructor = FindByCondition(g => g.InstructorID.Equals(id), trackChanges)
                  .SingleOrDefault();

            if (instructor is null)
            {
                throw new InstructorNotFoundException(id);
            }

            // Используем AutoMapper для преобразования Instructor в InstructorDto
            var instructorDto = _mapper.Map<InstructorDto>(instructor);

            return instructorDto;
        }
    
        public InstructorDto CreateInstuctor(InstructorForCreationDto instructorDto)
        {
            var instructorEntity = _mapper.Map<Instructor>(instructorDto);
            Create(instructorEntity);
            var instructorToReturn = _mapper.Map<InstructorDto>(instructorEntity);
            return instructorToReturn;
        }

        public void DeleteInstructor(int instructorId, bool trackChanges)
        {
            var instructor = _context.Set<Instructor>()
                .Where(g => g.InstructorID.Equals(instructorId))
                .AsNoTracking()
                .SingleOrDefault();

            if (instructor is null) throw new InstructorNotFoundException(instructorId);

            Delete(instructor);
            _context.SaveChanges();
        }
        public void UpdateInstructor(int instructorId, InstructorForUpdateDto instructorForUpdate, bool trackChanges)
        {
            var instructor = _context.Set<Instructor>()
                .Where(g => g.InstructorID.Equals(instructorId))
                .AsNoTracking()
                .SingleOrDefault();

            if (instructor is null) throw new InstructorNotFoundException(instructorId);

            var instructorEntity = FindByCondition(gt => gt.InstructorID.Equals(instructorId), trackChanges).SingleOrDefault();
            if (instructorEntity is null) throw new InstructorNotFoundException(instructorId);
            _mapper.Map(instructorForUpdate, instructorEntity);
            _context.SaveChanges();
        }
    }
    
}