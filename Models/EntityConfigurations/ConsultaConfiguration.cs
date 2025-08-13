using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASP.NET.Core.Identity.Models.Entities;

namespace ASP.NET.Core.Identity.Models.EntityConfigurations
{
    public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consultas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Data)
                   .IsRequired();
            
            builder.Property(c => c.Tipo)
                   .IsRequired();

            builder.HasOne(c => c.Paciente)
                   .WithMany(p => p.Consultas)
                   .HasForeignKey(c => c.IdPaciente);

            builder.HasOne(c => c.Medico)
                   .WithMany(m => m.Consultas)
                   .HasForeignKey(c => c.IdMedico);
        }
    }
}
