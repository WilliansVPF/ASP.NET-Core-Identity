using FluentValidation;
using ASP.NET.Core.Identity.Models.Contexts;
using ASP.NET.Core.Identity.ViewModels.Medico;

namespace ASP.NET.Core.Identity.Validators.Medico
{
    public class AdicionarMedicoValidator:AbstractValidator<AdicionarMedicoViewModel>
    {
        public AdicionarMedicoValidator(SisMedContext context)
        {
            RuleFor(x => x.CRM).NotEmpty().WithMessage("Campo obrigatório")
                               .Must(crm => !context.Medicos.Any(m => m.CRM == crm)).WithMessage("Este CRM já está cadastrado.");

            RuleFor(x => x.Nome).NotEmpty().WithMessage("Campo obrigatório")
                                .MaximumLength(100).WithMessage("O nome deve ter até {MaxLength} caracteres");
        }
    }
}
