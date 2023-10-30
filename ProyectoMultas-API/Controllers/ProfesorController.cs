using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMultas_API.Data;
using ProyectoMultas_API.Models;

namespace ProyectoMultas_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfesorController : ControllerBase
{
    private readonly ApplicactionDBContext _db;

    public ProfesorController(ApplicactionDBContext db)
    {
        _db = db;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registrar([FromBody] Profesor? profesor)
    {
        if (profesor == null) return BadRequest();

        Profesor? profesorEncontrado = await _db.Profesores.FirstOrDefaultAsync(
            p => p.IdBanner == profesor.IdBanner);

        if (profesorEncontrado != null) return Conflict();

        await _db.Profesores.AddAsync(profesor);

        await _db.SaveChangesAsync();

        return Ok(profesor);
    }

    [HttpPost("inicio")]
    public async Task<IActionResult> Iniciar([FromBody] ProfesorLoginDto? profesor)
    {
        if (profesor == null) return BadRequest();

        Profesor? profesorEncontrado = await _db.Profesores.FirstOrDefaultAsync(
            p => p.IdBanner == profesor.IdBanner);

        if (profesorEncontrado == null) return NotFound();

        if (profesorEncontrado.Contrasenia == profesor.Contrasenia) return Ok(profesorEncontrado);

        return Unauthorized();
    }

    [HttpPut("{idBanner}")]
    public async Task<IActionResult> ActualizarDatos(string idBanner, [FromBody] Profesor? profesor)
    {
        if (profesor == null) return BadRequest();

        Profesor? profesorEncontrado = await _db.Profesores.FirstOrDefaultAsync(
            p => p.IdBanner == idBanner);

        if (profesorEncontrado == null) return NotFound();

        profesorEncontrado.Nombre = profesor.Nombre;
        profesorEncontrado.Contrasenia = profesor.Contrasenia;

        _db.Profesores.Update(profesorEncontrado);
        await _db.SaveChangesAsync();

        return Ok(profesorEncontrado);
    }

    [HttpDelete("{idBanner}")]
    public async Task<IActionResult> EliminarCuenta(string idBanner)
    {
        Profesor? profesorEncontrado = await _db.Profesores.FirstOrDefaultAsync(
            p => p.IdBanner == idBanner);

        if (profesorEncontrado == null) return NotFound();
        _db.Remove(profesorEncontrado);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}