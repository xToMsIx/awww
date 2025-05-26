﻿using System.ComponentModel.DataAnnotations;
namespace SchoolRegister.ViewModels.VM;
using SchoolRegister.ViewModels.VM;
public class GroupVm
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public IList<StudentVm> Students { get; set; } = null!;
    public IList<SubjectVm> Subjects { get; set; } = null!;
}
