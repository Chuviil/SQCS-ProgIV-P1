using System.ComponentModel.DataAnnotations;

namespace ProyectoMultas_API.Models;

public class Profesor
{
    [Key] public string? IdBanner { get; set; }
    [Required] public string? Contrasenia { get; set; }
    public string? Nombre { get; set; }
}