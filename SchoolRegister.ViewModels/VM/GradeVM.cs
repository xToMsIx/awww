using System.ComponentModel.DataAnnotations;

public class GradeVm
{
    public int Id { get; set; }

    [Range(1, 6, ErrorMessage = "Wartość oceny musi być od 1 do 6")]
    public double Value { get; set; }

    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Nazwa przedmiotu jest wymagana")]
    public string SubjectName { get; set; } = null!;

    [Required(ErrorMessage = "Nazwa ucznia jest wymagana")]
    public string StudentName { get; set; } = null!;
}
