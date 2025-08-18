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
    public async Task<IActionResult> Login(LoginViewModel dados, string? returnUrl)
    {
        if (!ModelState.IsValid) return View(dados);
        var result = await _signManager.PasswordSignInAsync(dados.Username, dados.Senha, false, false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Usuário ou senha inválidod");
            return View(dados);
        }

        if (returnUrl is not null)
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _signManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
}