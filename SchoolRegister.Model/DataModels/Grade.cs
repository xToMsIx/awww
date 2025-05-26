using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public GradeScale GradeValue { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        required public virtual Subject Subject { get; set; }
        required public virtual Student Student { get; set; }

        public Grade()
        {
            DateOfIssue = DateTime.UtcNow;
        }
    }
}