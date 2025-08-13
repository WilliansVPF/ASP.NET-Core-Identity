namespace ASP.NET.Core.Identity.ViewModels.Paciente
{
    public class ListarPacienteViewModel
    {
        public int Id { get; set; }
        public string CPF { get; set; } = String.Empty;
        public string Nome { get; set; } = String.Empty;
    }
}
