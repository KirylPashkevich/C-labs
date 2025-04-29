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
    public class GroupRepository : IGroupRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public GroupRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<GroupDto> GetAllGroups(bool trackChanges) =>
            _mapper.Map<IEnumerable<GroupDto>>(_context.Groups);

        public GroupDto GetGroup(int id, bool trackChanges)
        {
            var group = _context.Groups.FirstOrDefault(g => g.GroupID == id);
            if (group == null)
                throw new InvalidOperationException($"Group with id: {id} doesn't exist.");
            return _mapper.Map<GroupDto>(group);
        }
    }
}