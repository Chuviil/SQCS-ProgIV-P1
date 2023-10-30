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

    public async Task<IActionResult> Delete(string idBanner)
    {
        await _api.EliminarAyudante(idBanner);
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(string idBanner)
    {
        var ayudante = await _api.ObtenerAyudante(idBanner);

        return View(ayudante);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Ayudante ayudante)
    {
        await _api.ActualizarAyudante(ayudante.IdBanner, ayudante);

        return RedirectToAction("Index");
    }
}