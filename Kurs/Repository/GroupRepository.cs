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
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        private readonly IMapper _mapper;

        public GroupRepository(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public IEnumerable<GroupDto> GetAllGroups(bool trackChanges)
        {
            var groups = FindAll(trackChanges)
                .OrderBy(g => g.GroupID)
                .ToList();

            var groupsDto = _mapper.Map<IEnumerable<GroupDto>>(groups);

            return groupsDto;
        }

        public GroupDto GetGroup(int id, bool trackChanges)
        {
            var group = FindByCondition(g => g.GroupID.Equals(id), trackChanges)
                .SingleOrDefault();

    
            if (group is null) throw new GroupNotFoundException(id);



            var groupDto = _mapper.Map<GroupDto>(group);

            return groupDto;
        }
        public GroupDto CreateGroup(int courseId, GroupForCreationDto group, bool trackChanges)
        {
            var courseToChek = _context.Set<Course>()
                .Where(g => g.CourseID.Equals(courseId))
                .AsNoTracking()
                .SingleOrDefault();

            if(courseToChek is null)
                throw new Exception();

            var groupEntity = _mapper.Map<Group>(group);
            groupEntity.CourseID = courseId;

            Create(groupEntity);

            var groupToReturn = _mapper.Map<GroupDto>(groupEntity);
            return groupToReturn;
        }
        public void DeleteGroup(int groupId, bool trackChanges)
        {
            var group = _context.Set<Group>()
                .Where(g => g.GroupID.Equals(groupId))
                .AsNoTracking()
                .FirstOrDefault();

            if (group is null) throw new GroupNotFoundException(groupId);

            Delete(group);
            _context.SaveChanges();
        }
        public void UpdateGroup(int groupId,int courseId, GroupForUpdateDto groupForUpdate, bool trackChanges)
        {
            var course = _context.Set<Course>()
                .Where(g => g.CourseID.Equals(courseId))
                .AsNoTracking()
                .SingleOrDefault();
            if (course is null) throw new CourseNotFoundException(courseId);
            var groupEntity = FindByCondition(gt => gt.GroupID.Equals(groupId), trackChanges).SingleOrDefault();
            if (groupEntity is null) throw new GroupNotFoundException(groupId);

            _mapper.Map(groupForUpdate, groupEntity);
            _context.SaveChanges();
        }
    }
}