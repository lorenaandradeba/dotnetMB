using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;

namespace Escambo.Infra.Configurations
{
    public class PrestacaoServicoHasAvaliacoesConfigurations : IEntityTypeConfiguration<PrestacaoServicoHasAvaliacoes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PrestacaoServicoHasAvaliacoes> builder)
        {
             //Uma avaliação pode estar associada a várias prestaçoes de servicos
            // e uma prestaçao de servicos pode ter várias avaliações associadas a ele
            //(O Prestador de servico avalia o Contratante e o Contratante avalia o prestador)
            //Por esse motivo criou-se a tabela intermediária PrestacaoServicoHasAvaliacoes
            //A tabela PrestacaoServicoHasAvaliacoes possui uma chave primária composta que consiste em duas colunas:
            // PrestacaoServicoIdPrestacaoServico e AvaliacoesIdAvaliacoes.
            builder
            .HasKey(pa => new { pa.PrestacaoServicoIdPrestacaoServico, pa.AvaliacoesIdAvaliacoes });
        }
    }
}