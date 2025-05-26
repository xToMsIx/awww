using System.ComponentModel.DataAnnotations;

public class ParentVm
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Imię i nazwisko rodzica jest wymagane")]
    public string FullName { get; set; } = null!;
}
