using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger<GroupService> logger)
        : base(dbContext, mapper, logger)
        {
        }
        public GroupVm AddOrUpdateGroup(GroupVm groupVm)
        {
            if (groupVm == null)
                throw new ArgumentNullException(nameof(groupVm));

            Group group;

            if (groupVm.Id != 0)
            {
                group = DbContext.Groups.Find(groupVm.Id);
                if (group == null) return null!;
                Mapper.Map(groupVm, group);
            }
            else
            {
                group = Mapper.Map<Group>(groupVm);
                DbContext.Groups.Add(group);
            }

            DbContext.SaveChanges();

            return Mapper.Map<GroupVm>(group);
        }

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterExpression)
        {
            var group = DbContext.Groups
                .Where(filterExpression)
                .FirstOrDefault();

            return group == null ? null! : Mapper.Map<GroupVm>(group);
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterExpression = null!)
        {
            var query = DbContext.Groups.AsQueryable();

            if (filterExpression != null)
                query = query.Where(filterExpression);

            return Mapper.ProjectTo<GroupVm>(query).ToList();
        }

        public void DeleteGroup(int groupId)
        {
            var group = DbContext.Groups.Find(groupId);
            if (group != null)
            {
                DbContext.Groups.Remove(group);
                DbContext.SaveChanges();
            }
        }
    }
}