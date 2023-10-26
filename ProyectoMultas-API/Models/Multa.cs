using System.ComponentModel.DataAnnotations;

namespace ProyectoMultas_API.Models;

public class Multa
{
    [Key] public int MultaId { get; set; }
    [Required] public double Monto { get; set; }
    [Required] public string? Razon { get; set; }
}