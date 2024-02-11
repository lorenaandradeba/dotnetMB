using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escambo.Infra.Configurations
{
    public class PrestacaoServicoHasUsuariosConfigurations : IEntityTypeConfiguration<PrestacaoServicoHasUsuarios>
    {
        public void Configure(EntityTypeBuilder<PrestacaoServicoHasUsuarios> builder)
        {
              //Uma prestação de servico pode estar associado a vários usuários (Prestador, Contratante), 
            //e um usuário pode estar associado a vários serviços de prestação. 
            //Por esse motivo criou-se a tabela intermediária PrestacaoServicoHasUsuarios 
            //A tabela PrestacaoServicoHasUsuarios  possui uma chave primária composta que consiste em duas colunas:
            // PrestacaoServicoIdPrestacaoServico e UsuariosIdUsuario.
            builder
                .HasKey(psu => new { psu.PrestacaoServicoIdPrestacaoServico, psu.UsuariosIdUsuario });

            //Cada registro em PrestacaoServicoHasUsuarios está associado a um único registro em PrestacaoServico
            builder
                .HasOne(psu => psu.PrestacaoServico)
                .WithMany(ps => ps.PrestacaoServicoHasUsuarios)
                .HasForeignKey(psu => psu.PrestacaoServicoIdPrestacaoServico);
            //Cada registro em PrestacaoServicoHasUsuarios está associado a um único registro em Usuario
            builder
                .HasOne(psu => psu.Usuario)
                .WithMany(u => u.PrestacaoServicoHasUsuarios)
                .HasForeignKey(psu => psu.UsuariosIdUsuario);
        }
    }
}