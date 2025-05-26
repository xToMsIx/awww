using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface ITeacherService
    {
        TeacherVm AddOrUpdateTeacher(TeacherVm teacherVm);
        TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression);
        IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterExpression);
        void DeleteTeacher(int teacherId);
    }
}
