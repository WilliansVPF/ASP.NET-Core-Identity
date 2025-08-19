using System.Threading.Tasks;
using ASP.NET.Core.Identity.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Core.Identity.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly SignInManager<IdentityUser> _signManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(ILogger<AuthController> logger, SignInManager<IdentityUser> signManager, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _signManager = signManager;
        _userManager = userManager;
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
        var result = await _signManager.PasswordSignInAsync(dados.Username, dados.Senha, dados.Lembrar, false);
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

    [Authorize]
    public IActionResult AlterarSenha()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AlterarSenha(AlterarSenhaViewModel dados)
    {
        if (!ModelState.IsValid) return View(dados);

        var user = await _userManager.GetUserAsync(User);
        var result = await _userManager.ChangePasswordAsync(user, dados.SenhaAtual, dados.NovaSenha);
        if (!result.Succeeded)
        {
            result.Errors.ToList().ForEach(x => ModelState.AddModelError(string.Empty, x.Description));
            return View(dados);
        }
        await _signManager.RefreshSignInAsync(user);
        return RedirectToAction(nameof(AlterarSenha));
    }
}