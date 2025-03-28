using Microsoft.AspNetCore.Mvc;

namespace EcoSimGame.Controllers.GameController;

public class GameController : Controller
{
    public IActionResult Index() => View();
}
