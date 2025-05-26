using System.ComponentModel.DataAnnotations;

public class TeacherVm
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Imię i nazwisko nauczyciela jest wymagane")]
    public string FullName { get; set; } = null!;
}
