using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class GradeService : BaseService, IGradeService
    {
        public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger<GradeService> logger)
            : base(dbContext, mapper, logger)
        {
        }

        public GradeVm AddOrUpdateGrade(GradeVm gradeVm)
        {
            try
            {
                if (gradeVm == null)
                    throw new ArgumentNullException(nameof(gradeVm));

                Grade? grade;

                if (gradeVm.Id != 0)
                {
                    grade = DbContext.Grades.Find(gradeVm.Id);
                    if (grade == null)
                        Mapper.Map(gradeVm, grade);
                }
                else
                {
                    grade = Mapper.Map<Grade>(gradeVm);
                    DbContext.Grades.Add(grade);
                }

                DbContext.SaveChanges();
                return Mapper.Map<GradeVm>(grade);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in AddOrUpdateGrade");
                throw;
            }
        }

        public GradeVm GetGrade(Expression<Func<Grade, bool>> filterExpression)
        {
            var grade = DbContext.Grades
            .Where(filterExpression)
            .FirstOrDefault();

        if (grade is null)
                throw new InvalidOperationException("Grade not found.");

            return Mapper.Map<GradeVm>(grade);
        }

        public IEnumerable<GradeVm> GetGrades(Expression<Func<Grade, bool>> filterExpression = null!)
        {
            try
            {
                var query = DbContext.Grades.AsQueryable();

                if (filterExpression != null)
                    query = query.Where(filterExpression);

                return Mapper.ProjectTo<GradeVm>(query).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in GetGrades");
                throw;
            }
        }

        public void DeleteGrade(int gradeId)
        {
            try
            {
                var grade = DbContext.Grades.Find(gradeId);
                if (grade != null)
                {
                    DbContext.Grades.Remove(grade);
                    DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in DeleteGrade");
                throw;
            }
        }
    }
}
