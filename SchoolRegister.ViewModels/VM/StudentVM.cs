using System.ComponentModel.DataAnnotations;

public class StudentVm
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Imię i nazwisko ucznia jest wymagane")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Nazwa grupy jest wymagana")]
    public string GroupName { get; set; } = null!;

    [Required(ErrorMessage = "Imię i nazwisko rodzica jest wymagane")]
    public string ParentName { get; set; } = null!;
}
