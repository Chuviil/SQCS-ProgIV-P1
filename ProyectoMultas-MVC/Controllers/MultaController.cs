using System.Text.Json;
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

    public async Task<IActionResult> Index()
    {
        ViewBag.Ayudantes = await _api.ObtenerAyudantes() ?? new List<Ayudante>();
        return View();
    }

    public async Task<IActionResult> Ayudante(string idBanner, string token)
    {
        try
        {
            var multas = await _api.ObtenerMultasPorId(idBanner);

            if (multas is null) return RedirectToAction("Index");

            ViewBag.idBanner = idBanner;
            ViewBag.Token = token;

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
        if (Request.Cookies.TryGetValue("user", out string? user))
        {
            Profesor? profesor = JsonSerializer.Deserialize<Profesor>(user);

            if (profesor != null) await _api.CrearMulta(multa, profesor.Token);
        
            return RedirectToAction("Ayudante", new { idBanner = multa.AyudanteId });
        }

        return RedirectToAction("InicioSesion", "Profesor");
    }

    public async Task<IActionResult> Delete(int multaId, string idBanner, string token)
    {
        await _api.EliminarMulta(multaId, token);

        return RedirectToAction("Ayudante", new { idBanner, token });
    }

    public async Task<IActionResult> Edit(int multaId, string token)
    {
        ViewBag.Token = token;

        var multa = await _api.ObtenerMulta(multaId);

        return View(multa);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Multa multa, string token)
    {
        await _api.ActualizarMulta(multa.MultaId, multa, token);

        return RedirectToAction("Ayudante", new { idBanner = multa.AyudanteId, token });
    }
}