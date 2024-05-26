using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicoss.Modelss;

    public class TiposTecnicos
    {
        [Key]

        public int TipoId { get; set; }
        [Required(ErrorMessage = "La Descripcion es incorrecta")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "La Incectivo es incorrecta")]
        public int Incentivo { get; set; }

        [ForeignKey("IncentivosTecnicos")]
        public int IncentivoId { get; set; }
    }

