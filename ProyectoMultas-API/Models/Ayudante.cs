using System.ComponentModel.DataAnnotations;

namespace ProyectoMultas_API.Models;

public class Ayudante
{
    [Key] public string IdBanner { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Carrera { get; set; } = null!;
    public ICollection<Multa> Multas { get; set; } = new List<Multa>();
}