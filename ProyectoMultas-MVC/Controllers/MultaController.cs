using Microsoft.AspNetCore.Mvc;
using ProyectoMultas.Models;
using ProyectoMultas.Services;

namespace ProyectoMultas.Controllers;

public class MultaController : Controller
{
    
    private readonly IApiService _api;

    public MultaController(IApiService api)
    {
        _api = api;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> Ayudante(string idBanner)
    {
        try
        {
            var multas = await _api.ObtenerMultasPorId(idBanner);
        
            if (multas is null) return RedirectToAction("Index");

            ViewBag.idBanner = idBanner;
        
            return View(multas);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index");
        }
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Ayudantes = await _api.ObtenerAyudantes() ?? new List<Ayudante>();
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Multa multa)
    {
        await _api.CrearMulta(multa);
        return RedirectToAction("Ayudante", new {idBanner = multa.AyudanteId});
    }
}