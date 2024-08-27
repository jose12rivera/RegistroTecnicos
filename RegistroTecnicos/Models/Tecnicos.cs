using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage ="Volver a Intentar Mas Tardes")]
    public string? Nombres { get; set; }
    [Required(ErrorMessage = "Volver a Intentar Mas Tardes")]
    public decimal? SueldoHora { get; set; }
}
