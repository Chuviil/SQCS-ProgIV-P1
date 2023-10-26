using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMultas_API.Data;

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

    /*// GET: api/Ayudante
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ayudantes = await _db.Ayudantes.ToListAsync();
        return Ok(ayudantes);
    }*/

    // GET: api/Ayudante/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }

    // POST: api/Ayudante
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Ayudante/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Ayudante/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}