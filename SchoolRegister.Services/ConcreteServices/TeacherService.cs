using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.ConcreteServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        public TeacherService(ApplicationDbContext dbContext, IMapper mapper, ILogger<TeacherService> logger)
        : base(dbContext, mapper, logger)
        {
        }

        public TeacherVm AddOrUpdateTeacher(TeacherVm teacherVm)
        {
            if (teacherVm == null) throw new ArgumentNullException(nameof(teacherVm));

            Teacher teacher;

            if (teacherVm.Id != 0)
            {
                teacher = DbContext.Teachers.Find(teacherVm.Id);
                if (teacher == null)
                    Mapper.Map(teacherVm, teacher);
            }
            else
            {
                teacher = Mapper.Map<Teacher>(teacherVm);
                DbContext.Teachers.Add(teacher);
            }

            DbContext.SaveChanges();
            return Mapper.Map<TeacherVm>(teacher);
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression)
        {
            var teacher = DbContext.Teachers.FirstOrDefault(filterExpression);
            return teacher == null ? null! : Mapper.Map<TeacherVm>(teacher);
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterExpression = null!)
        {
            var query = DbContext.Teachers.AsQueryable();

            if (filterExpression != null)
                query = query.Where(filterExpression);

            return Mapper.ProjectTo<TeacherVm>(query).ToList();
        }

        public void DeleteTeacher(int teacherId)
        {
            var teacher = DbContext.Teachers.Find(teacherId);
            if (teacher != null)
            {
                DbContext.Teachers.Remove(teacher);
                DbContext.SaveChanges();
            }
        }
    }
}