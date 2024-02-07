using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Core.Entities;

namespace TechMed.Infrastructure.Configurations;

public class ExameConfigurations : IEntityTypeConfiguration<Exame>
{

    public void Configure(EntityTypeBuilder<Exame> builder)
    {
        builder.ToTable("Exames").HasKey(e => e.ExameId);
        //colunas regras
        builder.Property(e => e.Nome).HasColumnType("longtext");

        builder.Property(e => e.Valor).HasColumnType("decimal(10,2)");

        builder.Property(e => e.Local).HasColumnType("longtext");

        builder.Property(e => e.ResultadoDescricao).HasColumnType("longtext");

        //chave unica
        builder
        .Property(e => e.ExameId).IsUnicode();

        //relacionamentos
        builder
        .HasMany(e => e.Atendimentos).WithMany(e => e.Exames)
        .UsingEntity<AtendimentoExame>(
            at => at
            .HasOne(ae => ae.Atendimento)
            .WithMany(a => a.AtendimentoExames)
            .HasForeignKey(ae => ae.AtendimentoId),
            ae => ae
            .HasOne(ae => ae.Exame)
            .WithMany(e => e.AtendimentoExames)
            .HasForeignKey(ae => ae.ExameId)
        );

    }
}