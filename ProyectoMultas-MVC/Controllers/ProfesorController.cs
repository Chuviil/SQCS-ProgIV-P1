using Microsoft.AspNetCore.Mvc;
using ProyectoMultas.Models;

namespace ProyectoMultas.Controllers;

public class ProfesorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Profesor profesor)
    {
        return RedirectToAction("Index","Home");
    }
}