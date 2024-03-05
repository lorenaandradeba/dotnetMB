using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escambo.Infra.Configurations
{
    public class MensagemConfiguraions : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            
            builder
            .ToTable("Mensagens")
            .HasKey(m => m.MensagemId);

            builder
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Mensagens)
                .HasForeignKey(m => m.UsuariosIdUsuario);
        }
    }
}