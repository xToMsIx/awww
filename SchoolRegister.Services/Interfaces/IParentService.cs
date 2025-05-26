using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IParentService
    {
        ParentVm AddOrUpdateParent(ParentVm parentVm);
        ParentVm GetParent(Expression<Func<Parent, bool>> filterExpression);
        IEnumerable<ParentVm> GetParents(Expression<Func<Parent, bool>> filterExpression);
        void DeleteParent(int parentId);
    }
}
