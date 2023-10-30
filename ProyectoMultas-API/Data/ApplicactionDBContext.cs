using Microsoft.EntityFrameworkCore;
using ProyectoMultas_API.Models;

namespace ProyectoMultas_API.Data;

public class ApplicactionDBContext : DbContext
{
    public ApplicactionDBContext(DbContextOptions<ApplicactionDBContext> options) : base(options)
    {
    }

    public DbSet<Ayudante> Ayudantes { get; set; }
    public DbSet<Multa> Multas { get; set; }
    public DbSet<Profesor> Profesores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ayudante>()
            .HasMany(e => e.Multas)
            .WithOne(e => e.Ayudante)
            .HasForeignKey(e => e.AyudanteId)
            .IsRequired();
    }
}