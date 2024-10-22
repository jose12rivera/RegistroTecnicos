using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Cotizaciones
{
    [Key]
    public int CotizacionId { get; set; }
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    [ForeignKey("ClienteId")]
    public Clientes? Clientes { get; set; }
    [StringLength(500, ErrorMessage = "La observación no puede tener más de 500 caracteres.")]
    public string? Observacion { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
    public double? Monto { get; set; }
    public ICollection<CotizacionesDetalle> CotizacionesDetalle { get; set; } = new List<CotizacionesDetalle>();
    public Articulos? Articulos { get; set; }
}
