using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Cotizaciones
{
    [Key]
    public int CotizacionId { get; set; }
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha  {get;set;}
    [ForeignKey("ClienteId")]
    [Required(ErrorMessage = "El ClienteId es obligatorio.")]
    public int ClienteId { get; set; }
    public Clientes? Clientes { get; set; }
    [StringLength(500, ErrorMessage = "La observación no puede tener más de 500 caracteres.")]
    public string? Observacion { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
    public double? Monto {  get; set; }
}
