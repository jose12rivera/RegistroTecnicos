using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;
public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public string? Nombres { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public decimal? SueldoHora { get; set; }

}
