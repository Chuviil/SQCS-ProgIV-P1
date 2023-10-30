using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMultas_API.Data;
using ProyectoMultas_API.Models;

namespace ProyectoMultas_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MultaController : ControllerBase
{
    private readonly ApplicactionDBContext _db;

    public MultaController(ApplicactionDBContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CrearMulta([FromBody] MultaDto multa)
    {
        Multa nuevaMulta = new Multa
        {
            Monto = multa.Monto,
            Razon = multa.Razon,
            AyudanteId = multa.AyudanteId
        };
        
        await _db.Multas.AddAsync(nuevaMulta);
        await _db.SaveChangesAsync();
        
        return Ok();
    }

    [HttpGet("{ayudanteId}")]
    public async Task<IActionResult> ObtenerMultasPorId(string ayudanteId)
    {
        /*
         VALIDACION PERO DA ERROR
         
         var ayudante = await _db.Ayudantes.FirstOrDefaultAsync(x => x.IdBanner == ayudanteId);
        
        if (ayudante == null)
        {
            return NotFound();
        }*/
        
        var multas = await _db.Multas.Where(m => m.AyudanteId == ayudanteId).ToListAsync();

        return Ok(multas);
    }

    [HttpPut("{multaId}")]
    public async Task<IActionResult> ActualizarMulta(int multaId, [FromBody] MultaDto multa)
    {
        var multaEncontrada = await _db.Multas.FirstOrDefaultAsync(m => m.MultaId == multaId);

        if (multaEncontrada is null) return NotFound();

        multaEncontrada.Monto = multa.Monto;
        multaEncontrada.Razon = multa.Razon;
        multaEncontrada.AyudanteId = multa.AyudanteId;

        _db.Multas.Update(multaEncontrada);

        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{multaId}")]
    public async Task<IActionResult> EliminarMulta(int multaId)
    {
        var multaEncontrada = await _db.Multas.FirstOrDefaultAsync(m => m.MultaId == multaId);

        if (multaEncontrada is null) return NotFound();

        _db.Multas.Remove(multaEncontrada);

        await _db.SaveChangesAsync();

        return Ok();
    }
}