using System.Collections.Generic;

namespace SchoolRegister.Model.DataModels
{
    public class Parent : User
    {
        required public virtual ICollection<Student> Students { get; set; }
    }
}
