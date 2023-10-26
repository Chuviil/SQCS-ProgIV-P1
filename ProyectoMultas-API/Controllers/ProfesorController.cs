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
    public async Task<IActionResult> Registro([FromBody] Profesor? profesor)
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
    public async Task<IActionResult> Inicio([FromBody] Profesor? profesor)
    {
        if (profesor == null) return BadRequest();
        
        Profesor? profesorEncontrado = await _db.Profesores.FirstOrDefaultAsync(
            p => p.IdBanner == profesor.IdBanner);

        if (profesorEncontrado == null) return NotFound();

        if (profesorEncontrado.Contrasenia == profesor.Contrasenia) return Ok(profesorEncontrado);
        
        return Unauthorized();
    }
}