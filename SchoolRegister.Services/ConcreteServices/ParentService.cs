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
    public class ParentService : BaseService, IParentService
    {
        public ParentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<ParentService> logger)
        : base(dbContext, mapper, logger)
        {
        }

        public ParentVm AddOrUpdateParent(ParentVm parentVm)
        {
            if (parentVm == null) throw new ArgumentNullException(nameof(parentVm));

            Parent parent;

            if (parentVm.Id != 0)
            {
                parent = DbContext.Parents.Find(parentVm.Id);
                if (parent == null) return null!;
                Mapper.Map(parentVm, parent);
            }
            else
            {
                parent = Mapper.Map<Parent>(parentVm);
                DbContext.Parents.Add(parent);
            }

            DbContext.SaveChanges();
            return Mapper.Map<ParentVm>(parent);
        }

        public ParentVm GetParent(Expression<Func<Parent, bool>> filterExpression)
        {
            var parent = DbContext.Parents.FirstOrDefault(filterExpression);
            return parent == null ? null! : Mapper.Map<ParentVm>(parent);
        }

        public IEnumerable<ParentVm> GetParents(Expression<Func<Parent, bool>> filterExpression = null!)
        {
            var query = DbContext.Parents.AsQueryable();

            if (filterExpression != null)
                query = query.Where(filterExpression);

            return Mapper.ProjectTo<ParentVm>(query).ToList();
        }

        public void DeleteParent(int parentId)
        {
            var parent = DbContext.Parents.Find(parentId);
            if (parent != null)
            {
                DbContext.Parents.Remove(parent);
                DbContext.SaveChanges();
            }
        }
    }
}