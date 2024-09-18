using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;
public class Prioridades
{
    [Key]
    public int PrioridadId { get; set; }
    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Por favor, asegúrate de que llenes campo")]
    public string? Tiempo { get; set; }
}
