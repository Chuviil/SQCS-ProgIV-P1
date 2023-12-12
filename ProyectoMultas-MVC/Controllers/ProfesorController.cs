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

    public IActionResult Index()
    {
        if (Request.Cookies.TryGetValue("user", out string? user))
        {
            Profesor? profesor = JsonSerializer.Deserialize<Profesor>(user);

            return View(profesor);
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Perfil()
    {
        if (Request.Cookies.TryGetValue("user", out string? user))
        {
            Profesor? profesor = JsonSerializer.Deserialize<Profesor>(user);

            return View(profesor);
        }

        return RedirectToAction("InicioSesion", "Profesor");
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
    public async Task<IActionResult> InicioSesion(ProfesorLoginDto profesor)
    {
        var profesorRes = await _api.IniciarSesion(profesor);

        if (profesorRes is null) return View();

        Response.Cookies.Append("user", JsonSerializer.Serialize(profesorRes), new CookieOptions()
        {
            Expires = DateTimeOffset.Now.AddDays(30)
        });

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Registro(Profesor profesor)
    {
        var profesorRes = await _api.Registrar(profesor);

        if (profesorRes is null) return View();

        Response.Cookies.Append("user", JsonSerializer.Serialize(profesorRes), new CookieOptions()
        {
            Expires = DateTimeOffset.Now.AddDays(30)
        });

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Perfil(Profesor? profesor)
    {
        if (profesor is not null)
        {
            var profesorActualizado = await _api.ActualizarProfesor(profesor.IdBanner, profesor, profesor.Token);

            if (profesorActualizado is null) return RedirectToAction("Error", "Home");

            profesorActualizado.Token = profesor.Token;

            Response.Cookies.Append("user", JsonSerializer.Serialize(profesorActualizado), new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(30)
            });
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> EliminarPerfil(string idBanner)
    {
        if (Request.Cookies.TryGetValue("user", out string? user))
        {
            Profesor? profesor = JsonSerializer.Deserialize<Profesor>(user);

            if (profesor != null) await _api.EliminarProfesor(idBanner, profesor.Token);
        }

        return RedirectToAction("InicioSesion");
    }

    public IActionResult CerrarSesion()
    {
        Response.Cookies.Delete("user");
        return RedirectToAction("Index", "Home");
    }
}