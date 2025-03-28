using EcoSimGame.Data;
using EcoSimGame.Models.AuthModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoSimGame.Controllers.AuthController;

public class AccountController : Controller
{
    private readonly GameDbContext _context;

    public AccountController(GameDbContext context) => _context = context;

    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
            if (userExists)
            {
                ModelState.AddModelError("Email", "Użytkownik o podanym adresie e-mail już istnieje.");
                return View(model);
            }

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Rejestracja przebiegła pomyślnie! Możesz teraz się zalogować.";

            return RedirectToAction("Login");
        }

        return View(model);
    }

    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                TempData["SuccessMessage"] = "Zalogowano pomyślnie!";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Nieprawidłowy adres e-mail lub hasło.");
        }

        return View(model);
    }
}