using Microsoft.AspNetCore.Mvc;

namespace ProyectoMultas.Controllers;

public class AyudanteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}