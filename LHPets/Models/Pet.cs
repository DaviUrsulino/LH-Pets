using System.ComponentModel.DataAnnotations;

namespace LHPets.Models;

public class Pet
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Nome { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    public string Especie { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    public string Raca { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "O ClienteId deve ser maior que zero.")]
    public int ClienteId { get; set; }
}
