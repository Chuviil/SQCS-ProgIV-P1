using System.ComponentModel.DataAnnotations;

namespace ProyectoMultas.Models;

public class Profesor
{
    public string? IdBanner { get; set; }
    [Required] public string? Contrasenia { get; set; }
    public string? Nombre { get; set; }
    public string Token { get; set; } = null!;
}