using Bitzen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Data.Mapping
{
    public class AbastecimentoMap : IEntityTypeConfiguration<Abastecimento>
    {
        public void Configure(EntityTypeBuilder<Abastecimento> builder)
        {
            builder.ToTable("tblAbastecimento");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Km)
              .HasColumnType("nvarchar(70)")
              .IsRequired();
            builder.Property(c => c.Litros)
              .HasColumnType("nvarchar(70)")
              .IsRequired();
            builder.Property(c => c.ValorPago)
             .HasColumnType("nvarchar(50)")
             .IsRequired();
            builder.Property(c => c.Data)
             .HasColumnType("datetime")
             .IsRequired();
            builder.Property(c => c.NomePosto)
             .HasColumnType("nvarchar(70)")
             .IsRequired();
            builder.Property(c => c.ativo)
             .HasColumnType("bit")
             .IsRequired();
            builder.Property(x => x.IdUsuario)
              .IsRequired();
            builder.Property(x => x.IdTipoCombustivel)
             .IsRequired();

           
        }
    }
}
