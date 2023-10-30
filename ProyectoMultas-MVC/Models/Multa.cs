namespace ProyectoMultas.Models;

public class Multa
{
    public int MultaId { get; set; }
    public double Monto { get; set; } = 0;
    public string Razon { get; set; } = null!;
    public Ayudante Ayudante { get; set; } = null!;
}