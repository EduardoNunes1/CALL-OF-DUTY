using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CallOfDuty.Models;
using CallOfDuty.Services;
namespace CallOfDuty.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICoDService _codService;
    public HomeController(ILogger<HomeController> logger, ICoDService codService)
    {
        _logger = logger;
        _codService = codService;
    }
    public IActionResult Index(string tipo)
    {
        var cods = _codService.GetCallOfDuty();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(cods);
    }
    public IActionResult Details(int Numero)
    {
        var personagem = _codService.GetPersonagens(Numero);

        return View(personagem);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id
        ?? HttpContext.TraceIdentifier });
    }
}
