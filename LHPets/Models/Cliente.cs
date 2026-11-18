using System.ComponentModel.DataAnnotations;

namespace LHPets.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Nome { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos numéricos.")]
    public string Cpf { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
