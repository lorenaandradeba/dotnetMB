using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escambo.Infra.Configurations
{
    public class ConversasHasUsuariosConfigurations : IEntityTypeConfiguration<ConversasHasUsuarios>
    {
        public void Configure(EntityTypeBuilder<ConversasHasUsuarios> builder)
        {
            
            builder
                .HasKey(cou => new {cou.ConversasIdMensagem, cou.UsuariosIdUsuario });

            builder
                .HasOne(cou => cou.Conversa)
                .WithMany(c => c.ConversasHasUsuarios)
                .HasForeignKey(cou => cou.ConversasIdMensagem);

            builder
                .HasOne(cou => cou.Usuario)
                .WithMany(u => u.ConversasHasUsuarios)
                .HasForeignKey(cou => cou.UsuariosIdUsuario);
        }
    }
}