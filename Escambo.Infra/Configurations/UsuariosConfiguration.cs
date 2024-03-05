using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Dommain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escambo.Infra.Configurations
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
            .ToTable("Usuarios")
            .HasKey(u => u.UsuarioId);

            //Um usuário pode ter vários anúncios
            builder
            .HasMany(u => u.Anuncios)
            .WithOne(a => a.Usuario)
            .HasForeignKey(a => a.UsuarioId);
        }

    }
}