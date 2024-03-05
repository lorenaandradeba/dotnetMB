using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escambo.Infra.Configurations
{
    public class ConversaConfigurations : IEntityTypeConfiguration<Conversa>
    {
        public void Configure(EntityTypeBuilder<Conversa> builder)
        {
           
            builder
            .ToTable("Conversas")
            .HasKey(c => c.ConversaId);
            
            builder
                .HasMany(c => c.Mensagens)
                .WithOne(m => m.Conversa)
                .HasForeignKey(m => m.ConversasIdMensagem);
        }
    }
}