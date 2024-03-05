using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escambo.Infra.Configurations
{
    public class PrestacaoConfigurations : IEntityTypeConfiguration<PrestacaoServico>
    {
        public void Configure(EntityTypeBuilder<PrestacaoServico> builder)
        {
            
            builder
            .ToTable("PrestacaoServicos")
            .HasKey(p => p.PrestacaoServicoId);

            //Uma prestação de serviço pode ter várias PrestacaoServicoHasAvaliacoes
            builder
                .HasMany(ps => ps.PrestacaoServicoHasAvaliacoes)
                .WithOne(pa => pa.PrestacaoServico)
                .HasForeignKey(pa => pa.PrestacaoServicoIdPrestacaoServico);//O PrestacaoServicoIdPrestacaoServico é a chave estrangeira na tabela de PrestacaoServicoHasAvaliacoes 
        }
    }
}