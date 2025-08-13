using System.Text.RegularExpressions;

namespace ASP.NET.Core.Identity.ViewModels.Medico
{
    public class AdicionarMedicoViewModel
    {
        private string crm = String.Empty;
        public string Nome { get; set; } = String.Empty;
        public string CRM { get; set; } = String.Empty;
    }
}
