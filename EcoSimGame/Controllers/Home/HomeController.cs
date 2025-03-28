using EcoSimGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcoSimGame.Controllers.Home;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;

    public IActionResult Index() => View();
    public IActionResult Login() => View("~/Views/Auth/Login.cshtml");
    public IActionResult Register() => View("~/Views/Auth/Register.cshtml");
}
