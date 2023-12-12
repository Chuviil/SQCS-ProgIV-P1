using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProyectoMultas.Models;

namespace ProyectoMultas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (Request.Cookies.TryGetValue("user", out string? user))
        {
            return RedirectToAction("Index", "Profesor");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}