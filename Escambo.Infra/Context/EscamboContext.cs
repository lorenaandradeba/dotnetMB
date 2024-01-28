
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Escambo.Infra.Context
{
    public class EscamboContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=dotnet;password=tic2023;database=escamboDB";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Um usuário pode ter vários anúncios
            modelBuilder.Entity<Usuario>()
                           .HasMany(u => u.Anuncios)
                           .WithOne(a => a.Usuario)
                           .HasForeignKey(a => a.UsuarioId);//O UsuarioIdUsuario é a chave estrangeira na tabela de Anúncios
            
            //Um anúncio pode estar associado a várias prestaçoes de servicos
            modelBuilder.Entity<Anuncio>()
                .HasMany(a => a.PrestacaoServicos)
                .WithOne(ps => ps.Anuncio)
                .HasForeignKey(ps => ps.AnuncioIdAnuncio);//O AnuncioIdAnuncio é a chave estrangeira na tabela de PrestacaoServico 

            //Uma avaliação pode estar associada a várias prestaçoes de servicos
            // e uma prestaçao de servicos pode ter várias avaliações associadas a ele
            //(O Prestador de servico avalia o Contratante e o Contratante avalia o prestador)
            //Por esse motivo criou-se a tabela intermediária PrestacaoServicoHasAvaliacoes
            //A tabela PrestacaoServicoHasAvaliacoes possui uma chave primária composta que consiste em duas colunas:
            // PrestacaoServicoIdPrestacaoServico e AvaliacoesIdAvaliacoes.
            modelBuilder.Entity<PrestacaoServicoHasAvaliacoes>()
                .HasKey(pa => new { pa.PrestacaoServicoIdPrestacaoServico, pa.AvaliacoesIdAvaliacoes });

            //Uma prestação de serviço pode ter várias PrestacaoServicoHasAvaliacoes
            modelBuilder.Entity<PrestacaoServico>()
                .HasMany(ps => ps.PrestacaoServicoHasAvaliacoes)
                .WithOne(pa => pa.PrestacaoServico)
                .HasForeignKey(pa => pa.PrestacaoServicoIdPrestacaoServico);//O PrestacaoServicoIdPrestacaoServico é a chave estrangeira na tabela de PrestacaoServicoHasAvaliacoes 

            //Uma prestação de servico pode estar associado a vários usuários (Prestador, Contratante), 
            //e um usuário pode estar associado a vários serviços de prestação. 
            //Por esse motivo criou-se a tabela intermediária PrestacaoServicoHasUsuarios 
            //A tabela PrestacaoServicoHasUsuarios  possui uma chave primária composta que consiste em duas colunas:
            // PrestacaoServicoIdPrestacaoServico e UsuariosIdUsuario.
            modelBuilder.Entity<PrestacaoServicoHasUsuarios>()
                .HasKey(psu => new { psu.PrestacaoServicoIdPrestacaoServico, psu.UsuariosIdUsuario });

            //Cada registro em PrestacaoServicoHasUsuarios está associado a um único registro em PrestacaoServico
            modelBuilder.Entity<PrestacaoServicoHasUsuarios>()
                .HasOne(psu => psu.PrestacaoServico)
                .WithMany(ps => ps.PrestacaoServicoHasUsuarios)
                .HasForeignKey(psu => psu.PrestacaoServicoIdPrestacaoServico);
            //Cada registro em PrestacaoServicoHasUsuarios está associado a um único registro em Usuario
            modelBuilder.Entity<PrestacaoServicoHasUsuarios>()
                .HasOne(psu => psu.Usuario)
                .WithMany(u => u.PrestacaoServicoHasUsuarios)
                .HasForeignKey(psu => psu.UsuariosIdUsuario);


            modelBuilder.Entity<Conversa>()
                .HasMany(c => c.Mensagens)
                .WithOne(m => m.Conversa)
                .HasForeignKey(m => m.ConversasIdMensagem);

            modelBuilder.Entity<Mensagem>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Mensagens)
                .HasForeignKey(m => m.UsuariosIdUsuario);


            modelBuilder.Entity<ConversasHasUsuarios>()
                .HasKey(cou => new {cou.ConversasIdMensagem, cou.UsuariosIdUsuario });

            modelBuilder.Entity<ConversasHasUsuarios>()
                .HasOne(cou => cou.Conversa)
                .WithMany(c => c.ConversasHasUsuarios)
                .HasForeignKey(cou => cou.ConversasIdMensagem);

            modelBuilder.Entity<ConversasHasUsuarios>()
                .HasOne(cou => cou.Usuario)
                .WithMany(u => u.ConversasHasUsuarios)
                .HasForeignKey(cou => cou.UsuariosIdUsuario);

        }

    }
}