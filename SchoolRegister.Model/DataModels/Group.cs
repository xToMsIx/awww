using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Model.DataModels
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        required public string Name { get; set; }

        required public virtual ICollection<Student> Students { get; set; }
        required public virtual ICollection<SubjectGroup> SubjectGroups { get; set; }
    }
}
