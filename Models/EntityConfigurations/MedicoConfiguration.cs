using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASP.NET.Core.Identity.Models.Entities;

namespace ASP.NET.Core.Identity.Models.EntityConfigurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.CRM)
                   .IsRequired()
                   .HasMaxLength(13);

            builder.HasIndex(m => m.CRM)
                   .IsUnique();

            builder.Property(m => m.Nome)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
