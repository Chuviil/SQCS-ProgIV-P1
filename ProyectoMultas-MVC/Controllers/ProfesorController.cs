using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProyectoMultas.Models;
using ProyectoMultas.Services;

namespace ProyectoMultas.Controllers;

public class ProfesorController : Controller
{
    private readonly IApiService _api;

    public ProfesorController(IApiService api)
    {
        _api = api;
    }

    public IActionResult Index(Profesor profesor)
    {
        return View(profesor);
    }

    public IActionResult InicioSesion()
    {
        return View();
    }
    
    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> InicioSesion(Profesor profesor)
    {
        var profesorRes = await _api.IniciarSesion(profesor);
        
        return RedirectToAction("Index", profesorRes);
    }
    
    [HttpPost]
    public async Task<IActionResult> Registro(Profesor profesor)
    {
        var profesorRes = await _api.Registrar(profesor);
        
        return RedirectToAction("Index", profesorRes);
    }
}