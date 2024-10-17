using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a cero.")]
    public decimal Costo { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "La existencia es obligatoria.")]
    [Range(0, int.MaxValue, ErrorMessage = "La existencia no puede ser negativa.")]
    public int Existencia { get; set; }

}
