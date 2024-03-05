using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escambo.Infra.Configurations
{
    public class AvaliacaoConfigurations : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            
            builder
            .ToTable("Avaliacoes")
            .HasKey(a => a.AvaliacaoId);
        }
    }
}