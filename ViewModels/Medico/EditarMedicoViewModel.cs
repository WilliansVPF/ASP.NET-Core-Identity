using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Core.Identity.ViewModels.Medico
{
    public class EditarMedicoViewModel
    {
        public int Id { get; set; }
        
        public string Nome { get; set; } = String.Empty;

        public string CRM { get; set; } = String.Empty;
    }
}
