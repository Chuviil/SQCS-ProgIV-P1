using System.ComponentModel.DataAnnotations;

namespace ProyectoMultas_API.Models;

public class Multa
{
    [Key] public int MultaId { get; set; }
    public double Monto { get; set; } = 0;
    public string Razon { get; set; } = null!;
    public string AyudanteId { get; set; } = null!;
    public Ayudante Ayudante { get; set; } = null!;
}