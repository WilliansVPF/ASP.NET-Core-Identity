using System.ComponentModel;

namespace ASP.NET.Core.Identity.ViewModels.Usuario;

public class BaseFormUsuarioViewModel
{
    public string Username { get; set; } = string.Empty;

    [DisplayName("E-mail")]
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}