using Microsoft.AspNetCore.Mvc;

namespace EcoSimGame.Controllers
{
    public class GameController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
