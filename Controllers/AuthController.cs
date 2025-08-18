using ASP.NET.Core.Identity.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Core.Identity.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly SignInManager<IdentityUser> _signManager;

    public AuthController(ILogger<AuthController> logger, SignInManager<IdentityUser> signManager)
    {
        _logger = logger;
        _signManager = signManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel dados)
    {
        if (!ModelState.IsValid) return View(dados);
        var result = await _signManager.PasswordSignInAsync(dados.Username, dados.Senha, false, false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Usuário ou senha inválidod");
            return View(dados);
        }
        return RedirectToAction("Index", "Home");
    }
}