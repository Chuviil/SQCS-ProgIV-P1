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
    
    public async Task<IActionResult> Index(string token)
    {
        var ayudantes = await _api.ObtenerAyudantes();
        ViewBag.Token = token;
        
        return View(ayudantes);
    }

    public IActionResult Create(string token)
    {
        ViewBag.Token = token;
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ayudante ayudante, string token)
    {
        await _api.CrearAyudante(ayudante, token);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(string idBanner, string token)
    {
        await _api.EliminarAyudante(idBanner, token);
        var ayudantes = await _api.ObtenerAyudantes();
        
        ViewBag.Token = token;
        
        return View("Index", ayudantes);
    }

    public async Task<IActionResult> Edit(string idBanner, string token)
    {
        var ayudante = await _api.ObtenerAyudante(idBanner);
        
        ViewBag.Token = token;

        return View(ayudante);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Ayudante ayudante, string token)
    {
        await _api.ActualizarAyudante(ayudante.IdBanner, ayudante, token);
        
        var ayudantes = await _api.ObtenerAyudantes();
        ViewBag.Token = token;

        return View("Index", ayudantes);
    }
}