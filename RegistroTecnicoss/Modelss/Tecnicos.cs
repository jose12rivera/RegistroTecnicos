using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicoss.Modelss
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "Por Favor Ingresar El Nombre")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Por Favor Ingresar El Sueldo Por Hora")]
        public float? Sueldohora { get; set; }

        [ForeignKey("TiposTecnicos")]
        public int TipoId { get; set; }

        public int IncentivoId { get; set; }
        public TiposTecnicos? TiposTecnicos { get; set; }
    }
}
