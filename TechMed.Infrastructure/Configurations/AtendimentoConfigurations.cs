using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Core.Entities;

namespace TechMed.Infrastructure.Configurations;

public class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder
        .ToTable("Atendimentos")
        .HasKey(a => a.AtendimentoId);
        builder
        .HasOne(a => a.Medico).WithMany(a => a.Atendimentos).HasForeignKey(a => a.MedicoId);
        builder
        .HasOne(a => a.Paciente).WithMany(a => a.Atendimentos).HasForeignKey(a => a.PacienteId);

    }
}