using System.ComponentModel;

namespace ASP.NET.Core.Identity.ViewModels.Usuario;

public class AdicionarUsuarioViewModel : BaseFormUsuarioViewModel
{
    public string Senha { get; set; } = string.Empty;

    [DisplayName("Confirmação Senha")]
    public string ConfirmacaoSenha { get; set; } = string.Empty;
}