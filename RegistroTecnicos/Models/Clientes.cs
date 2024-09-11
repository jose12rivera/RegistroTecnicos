using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public string? Nombres{ get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public string? WhatsApp { get; set; }
}
