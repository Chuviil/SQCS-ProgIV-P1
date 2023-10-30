using Microsoft.AspNetCore.Mvc;
using ProyectoMultas.Models;
using ProyectoMultas.Services;

namespace ProyectoMultas.Controllers;

public class AyudanteController : Controller
{
    private readonly IApiService _api;

    public AyudanteController(IApiService api)
    {
        _api = api;
    }
    
    public async Task<IActionResult> Index()
    {
        var ayudantes = await _api.ObtenerAyudantes();
        
        return View(ayudantes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ayudante ayudante)
    {
        await _api.CrearAyudante(ayudante);

        return RedirectToAction("Index");
    }
}