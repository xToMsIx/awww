using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        [ForeignKey("Group")]
        public int? GroupId { get; set; }

        required public virtual Group Group { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        required public virtual Parent Parent { get; set; }

        required public virtual ICollection<Grade> Grades { get; set; }
    }
}
