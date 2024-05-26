using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicoss.Modelss
{
    public class IncentivosTecnicos
    {
        [Key]

        public int IncentivoId { get; set; }
        [Required(ErrorMessage = "Por Favor Ingresar La Fecha")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Por Favor Ingresar El Tecnico Id")]
        public int TecnicoId { get; set; }
        [Required(ErrorMessage = "Por Favor Ingresar La Descripcion")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Por Favor Ingresar La Cantidad de Servicios")]
        public int CantidadServicios { get; set; }
        [Required(ErrorMessage = "Por Favor Ingresar El Monto")]
        public decimal Monto{ get; set; }

    }
}
