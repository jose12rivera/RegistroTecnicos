using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;
public class TiposTecnicos
{
    [Key]
    public int TipoId { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public string? Descripcion { get; set; }
    public Tecnicos? Tecnicos { get; set; }
}
