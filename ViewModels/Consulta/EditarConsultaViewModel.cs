using System.ComponentModel.DataAnnotations;
using ASP.NET.Core.Identity.Models.Enums;

namespace ASP.NET.Core.Identity.ViewModels.Consulta
{
    public class EditarConsultaViewModel
    {
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public TipoConsulta Tipo { get; set; }

        [Display(Name = "Paciente")]
        public int IdPaciente { get; set; }
        
        public string NomePaciente { get; set; } = String.Empty;

        [Display(Name = "Médico")]
        public int IdMedico { get; set; }
    }
}
