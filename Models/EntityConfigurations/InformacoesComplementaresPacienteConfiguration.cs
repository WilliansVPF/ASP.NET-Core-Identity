using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASP.NET.Core.Identity.Models.Entities;

namespace ASP.NET.Core.Identity.Models.EntityConfigurations
{
    public class InformacoesComplementaresPacienteConfiguration : IEntityTypeConfiguration<InformacoesComplementaresPaciente>
    {
        public void Configure(EntityTypeBuilder<InformacoesComplementaresPaciente> builder)
        {
            builder.ToTable("InformacoesComplementaresPaciente");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Alergias)
                   .HasMaxLength(200);
            
            builder.Property(i => i.MedicamentosEmUso)
                   .HasMaxLength(200);
            
            builder.Property(i => i.CirurgiasRealizadas)
                   .HasMaxLength(200);
        }
    }
}
