using Bitzen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tblUsuario");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
              .HasColumnType("nvarchar(80)")
              .IsRequired();

            builder.Property(c => c.Login)
              .HasColumnType("nvarchar(70)");

            builder.Property(c => c.Senha)
              .HasColumnType("nvarchar(50)")
              .IsRequired();

            builder.Property(c => c.Email)
              .HasColumnType("nvarchar(70)");

            builder.Property(x => x.IdPermissao)
              .IsRequired();

            builder.HasOne<Permissao>(x => x.Permissao)
              .WithMany(s => s.Usuarios)
              .HasForeignKey(z => z.IdPermissao);

            builder.Property(c => c.Ativo)
              .HasColumnType("bit")
              .IsRequired();
        }
    }

}
