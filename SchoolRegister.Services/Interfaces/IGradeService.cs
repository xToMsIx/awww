﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        GradeVm AddOrUpdateGrade(GradeVm gradeVm);
        GradeVm GetGrade(Expression<Func<Grade, bool>> filterExpression);
        IEnumerable<GradeVm> GetGrades(Expression<Func<Grade, bool>> filterExpression);
        void DeleteGrade(int gradeId);
    }
}
