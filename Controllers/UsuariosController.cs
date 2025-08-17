using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Core.Identity.Controllers;

public class UsuariosController : Controller
{
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(ILogger<UsuariosController> logger)
    {
        _logger = logger;
    }

    public IActionResult Adicionar()
    {
        return View();
    }
}