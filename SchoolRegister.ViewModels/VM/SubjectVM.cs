namespace SchoolRegister.ViewModels.VM
{
    public class SubjectVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
        public IList<GroupVm> Groups { get; set; } = null!;
    }
}