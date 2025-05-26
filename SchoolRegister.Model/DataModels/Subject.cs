using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        required public string Name { get; set; }
        required public string Description { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }

        required public virtual Teacher Teacher { get; set; }
        required public virtual ICollection<SubjectGroup> SubjectGroups { get; set; }
        required public virtual ICollection<Grade> Grades { get; set; }
    }
}
