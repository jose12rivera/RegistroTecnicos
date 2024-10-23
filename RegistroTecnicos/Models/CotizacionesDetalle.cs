using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class CotizacionesDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int CotizacionId { get; set; }

    [ForeignKey("CotizacionId")]
    public Cotizaciones? Cotizaciones { get; set; }

    public int ArticuloId { get; set; }

    [ForeignKey("ArticuloId")]
    public Articulos? Articulos { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
    public int Cantidad { get; set; } // Cambiado a decimal

    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
    public decimal Precio { get; set; }
}
