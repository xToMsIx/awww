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
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<StudentService> logger)
        : base(dbContext, mapper, logger)
        {
        }

        public StudentVm AddOrUpdateStudent(StudentVm studentVm)
        {
            if (studentVm == null) throw new ArgumentNullException(nameof(studentVm));

            Student student;

            if (studentVm.Id != 0)
            {
                student = DbContext.Students.Find(studentVm.Id);
                if (student == null) return null!;
                Mapper.Map(studentVm, student);
            }
            else
            {
                student = Mapper.Map<Student>(studentVm);
                DbContext.Students.Add(student);
            }

            DbContext.SaveChanges();
            return Mapper.Map<StudentVm>(student);
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> filterExpression)
        {
            var student = DbContext.Students.FirstOrDefault(filterExpression);
            return student == null ? null! : Mapper.Map<StudentVm>(student);
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterExpression = null!)
        {
            var query = DbContext.Students.AsQueryable();

            if (filterExpression != null)
                query = query.Where(filterExpression);

            return Mapper.ProjectTo<StudentVm>(query).ToList();
        }

        public void DeleteStudent(int studentId)
        {
            var student = DbContext.Students.Find(studentId);
            if (student != null)
            {
                DbContext.Students.Remove(student);
                DbContext.SaveChanges();
            }
        }
    }
}