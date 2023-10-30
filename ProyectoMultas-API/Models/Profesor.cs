using System.ComponentModel.DataAnnotations;

namespace ProyectoMultas_API.Models;

public class Profesor
{
    [Key] public string IdBanner { get; set; } = String.Empty;
    [Required] public string Contrasenia { get; set; } = String.Empty;
    [Required] public string Nombre { get; set; } = String.Empty;
}