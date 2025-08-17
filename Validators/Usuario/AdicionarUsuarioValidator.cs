using ASP.NET.Core.Identity.ViewModels.Usuario;
using FluentValidation;

namespace ASP.NET.Core.Identity.Validators.Usuario;

class AdicionarUsuarioValidator : AbstractValidator<AdicionarUsuarioViewModel>
{
    public AdicionarUsuarioValidator()
    {
        RuleFor(usuario => usuario.Username)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio")
            .MaximumLength(50).WithMessage("O campo {PropertyName} deve ter no mámaximo {MaxLength} caracteres");

        RuleFor(usuario => usuario.Telefone)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio")
            .Length(11).WithMessage("O campo {PropertyName} deve ter {MaxLength} caracteres")
            .Must(valor => valor.ToList().All(c => char.IsDigit(c))).WithMessage("O campo {PropertyName} deve conter apenas números");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
            .EmailAddress().WithMessage("O campo {PropertyName} está em um formato inválido");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
            .MinimumLength(3).WithMessage("O campo {PropertyName} deve ter no mínimo {MinLength} caracteres");
            
        RuleFor(x => x.ConfirmacaoSenha)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
            .Equal(x => x.Senha).WithMessage("O campo {PropertyName} deve ser igual ao campo Senha");
    }
}