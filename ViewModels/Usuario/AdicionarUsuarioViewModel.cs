using System.ComponentModel;

namespace ASP.NET.Core.Identity.ViewModels.Usuario;

public class AdicionarUsuarioViewModel
{
    public string Username { get; set; } = string.Empty;

    [DisplayName("E-mail")]
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;

    [DisplayName("Confirmação Senha")]
    public string ConfirmacaoSenha { get; set; } = string.Empty;
}