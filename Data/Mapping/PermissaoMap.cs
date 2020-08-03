using Bitzen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Data.Mapping
{
    public class PermissaoMap : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("tblPermissao");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
              .HasColumnType("nvarchar(150)")
              .IsRequired();

            builder.Property(c => c.Ativo)
              .HasColumnType("bit")
              .IsRequired();

            builder
              .HasMany(x => x.Usuarios)
              .WithOne(z => z.Permissao);
        }
    }
}
