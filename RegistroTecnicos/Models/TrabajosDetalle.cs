using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class TrabajosDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int TrabajoId { get; set; }

    [ForeignKey("TrabajoId")]
    public Trabajos Trabajo { get; set; }

    public int ArticuloId { get; set; }

    [ForeignKey("ArticuloId")]
    public Articulos Articulo { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero.")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a cero.")]
    public decimal Costo { get; set; }
}
