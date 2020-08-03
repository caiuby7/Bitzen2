using Bitzen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Data.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("tblVeiculo");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Marca)
              .HasColumnType("nvarchar(80)")
              .IsRequired();
            builder.Property(c => c.Modelo)
              .HasColumnType("nvarchar(70)")
              .IsRequired();
            builder.Property(c => c.Ano)
             .HasColumnType("nvarchar(4)")
             .IsRequired();
            builder.Property(c => c.Placa)
             .HasColumnType("nvarchar(10)")
             .IsRequired();
            builder.Property(c => c.KM)
             .HasColumnType("int")
             .IsRequired();
            builder.Property(x => x.IdUsuario)
              .IsRequired();
            builder.Property(x => x.IdTipoVeiculo)
             .IsRequired();

           
        }
    }
}
