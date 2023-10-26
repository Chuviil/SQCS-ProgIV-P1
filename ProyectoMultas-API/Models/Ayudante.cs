using System.ComponentModel.DataAnnotations;

namespace ProyectoMultas_API.Models;

public class Ayudante
{
    [Key] public string? IdBanner { get; set; }
    [Required] public string? Nombre { get; set; }
    [Required] public string? Carrera { get; set; }
}