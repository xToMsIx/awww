using System.Collections.Generic;

namespace SchoolRegister.Model.DataModels
{
    public class Teacher : User
    {
        required public virtual ICollection<Subject> Subjects { get; set; }
    }
}