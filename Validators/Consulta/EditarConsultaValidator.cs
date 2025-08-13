using FluentValidation;
using System.Text.RegularExpressions;
using ASP.NET.Core.Identity.Models.Contexts;
using ASP.NET.Core.Identity.ViewModels.Consulta;

namespace ASP.NET.Core.Identity.Validators.Consulta
{
    public class EditarConsultaValidator:AbstractValidator<EditarConsultaViewModel>
    {
        private readonly SisMedContext _context;
        public EditarConsultaValidator(SisMedContext context)
        {
            _context = context;

            RuleFor(x => x.Data).NotEmpty().WithMessage("Campo obrigatório")
                                .Must(data => data >= DateTime.Today).WithMessage("A data da consulta não pode ser anterior ao dia atual");

            RuleFor(x => x.Tipo).NotNull().WithMessage("Campo obrigatório");
            
            RuleFor(x => x.IdPaciente).NotNull().WithMessage("Campo obrigatório");
            
            RuleFor(x => x.IdMedico).NotNull().WithMessage("Campo obrigatório");
        }
    }
}
