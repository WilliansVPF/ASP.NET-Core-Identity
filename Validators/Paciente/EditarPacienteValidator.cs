using FluentValidation;
using System.Text.RegularExpressions;
using ASP.NET.Core.Identity.Models.Contexts;
using ASP.NET.Core.Identity.ViewModels.Paciente;

namespace ASP.NET.Core.Identity.Validators.Paciente
{
    public class EditarPacienteValidator:AbstractValidator<EditarPacienteViewModel>
    {
        public EditarPacienteValidator(SisMedContext context)
        {
            RuleFor(x => x.CPF).NotEmpty().WithMessage("Campo obrigatório")
                               .Must(cpf => Regex.Replace(cpf, "[^0-9]", "").Length == 11).WithMessage("CPF inválido");

            RuleFor(x => x.Nome).NotEmpty().WithMessage("Campo obrigatório")
                                .MaximumLength(100).WithMessage("O nome deve ter até {MaxLength} caracteres");

            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("Campo obrigatório")
                                          .Must(data => data <= DateTime.Today).WithMessage("A data de nascimento não pode ser futura.");

            RuleFor(x => x).Must(x => !context.Pacientes.Any(paciente => paciente.CPF == Regex.Replace(x.CPF, "[^0-9]", "") && paciente.Id != x.Id)).WithMessage("Este CPF já está cadastrado.");
        }
    }
}
