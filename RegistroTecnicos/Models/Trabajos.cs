using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Trabajos
{
    [Key]
    public int TrabajoId { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public  DateTime? Fecha { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public decimal? Monto { get; set; }

    [ForeignKey("Tecnicos")]
    public int TecnicoId { get; set; }
    public Tecnicos? Tecnicos { get; set; }

    [ForeignKey("Clientes")]
    public int ClienteId { get; set; }
    public Clientes? Clientes { get; set; }
}
