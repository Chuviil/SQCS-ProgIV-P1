using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMultas_API.Data;
using ProyectoMultas_API.Models;

namespace ProyectoMultas_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AyudanteController : ControllerBase
{
    private readonly ApplicactionDBContext _db;

    public AyudanteController(ApplicactionDBContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CrearAyudante([FromBody] Ayudante ayudante)
    {
        await _db.Ayudantes.AddAsync(ayudante);
        await _db.SaveChangesAsync();
        return Ok(ayudante);
    }
    
    [HttpGet("{idBanner}")]
    public async Task<IActionResult> ObtenerAyudante(string idBanner)
    {
        var ayudante = await _db.Ayudantes.FirstOrDefaultAsync(a => a.IdBanner == idBanner);
        return Ok(ayudante);
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerAyudantes()
    {
        var ayudantes = await _db.Ayudantes.ToListAsync();
        return Ok(ayudantes);
    }

    [HttpPut("{idBanner}")]
    public async Task<IActionResult> ActualizarAyudante(string idBanner, [FromBody] Ayudante? ayudante)
    {
        if (ayudante == null) return BadRequest();

        var ayudanteEncontrado = await _db.Ayudantes.FirstOrDefaultAsync(a => a.IdBanner == idBanner);
        
        if (ayudanteEncontrado is null) return NotFound();
        
        ayudanteEncontrado.Nombre = ayudante.Nombre;
        ayudanteEncontrado.Carrera = ayudante.Carrera;

        _db.Ayudantes.Update(ayudanteEncontrado);
        
        await _db.SaveChangesAsync();
        
        return Ok();
    }

    [HttpDelete("{idBanner}")]
    public async Task<IActionResult> EliminarAyudante(string idBanner)
    {
        var ayudanteEncontrado = await _db.Ayudantes.FirstOrDefaultAsync(a => a.IdBanner == idBanner);
        
        if (ayudanteEncontrado is null) return NotFound();
        
        _db.Ayudantes.Remove(ayudanteEncontrado);
        
        await _db.SaveChangesAsync();
        
        return NoContent();
    }
}