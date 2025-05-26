using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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
    public class SubjectService : BaseService, ISubjectService
    {
        public SubjectService(ApplicationDbContext dbContext, IMapper mapper, ILogger<SubjectService> logger)
            : base(dbContext, mapper, logger)
        {
        }

        public SubjectVm? AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm)
        {
            if (addOrUpdateVm == null)
                throw new ArgumentNullException(nameof(addOrUpdateVm));

            Subject? subject;

            if (addOrUpdateVm.Id.HasValue)
            {
                subject = DbContext.Subjects.Find(addOrUpdateVm.Id.Value);
                if (subject == null) return null;
                Mapper.Map(addOrUpdateVm, subject);
            }
            else
            {
                subject = Mapper.Map<Subject>(addOrUpdateVm);
                DbContext.Subjects.Add(subject);
            }

            DbContext.SaveChanges();
            return Mapper.Map<SubjectVm>(subject);
        }

        public SubjectVm? GetSubject(Expression<Func<Subject, bool>> filterExpression)
        {
            var subject = DbContext.Subjects.FirstOrDefault(filterExpression);
            return subject == null ? null : Mapper.Map<SubjectVm>(subject);
        }

        public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>>? filterExpression = null)
        {
            var query = DbContext.Subjects.AsQueryable();

            if (filterExpression != null)
                query = query.Where(filterExpression);

            return Mapper.ProjectTo<SubjectVm>(query).ToList();
        }
    }
}
