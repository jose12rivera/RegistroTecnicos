using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class CotizacionesDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("CotizacionId")]
    [Required(ErrorMessage = "La CotizacionId es obligatorio.")]
    public int CotizacionId { get; set;}
    public Cotizaciones? Cotizaciones { get; set; }

    [ForeignKey("ArticuloId")]
    [Required(ErrorMessage = "El ArticuloId es obligatorio.")]
    public int ArticuloId { get; set; }

    public Articulos? Articulos { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
    public decimal? Cantidad { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "El Precio debe ser mayor que 0.")]
    public double? Precio { get; set; }
}
