using System.ComponentModel.DataAnnotations;

public class AddOrUpdateSubjectVm
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Nazwa jest wymagana")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Id nauczyciela jest wymagane")]
    [Range(1, int.MaxValue, ErrorMessage = "Wybierz poprawnego nauczyciela")]
    public int TeacherId { get; set; }
}
