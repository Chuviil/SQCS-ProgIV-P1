using Microsoft.AspNetCore.Mvc;
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
}