using Bitzen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Data.Mapping
{
    public class TipoCombustivelMap : IEntityTypeConfiguration<TipoCombustivel>
    {
        public void Configure(EntityTypeBuilder<TipoCombustivel> builder)
        {
            builder.ToTable("tblTipoCombustivel");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
              .HasColumnType("nvarchar(150)")
              .IsRequired();

           
            builder
              .HasMany(x => x.Abastecimentos)
              .WithOne(z => z.tipocombustivel);
        }
    }
}
