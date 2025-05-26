using SchoolRegister.Model.DataModels;

public class SubjectGroup
{
    public int SubjectId { get; set; }
    public int GroupId { get; set; }

    required public virtual Subject Subject { get; set; }
    required public virtual Group Group { get; set; }
}
