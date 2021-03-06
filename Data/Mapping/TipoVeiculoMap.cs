﻿using Bitzen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Data.Mapping
{
    public class TipoVeiculoMap : IEntityTypeConfiguration<TipoVeiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVeiculo> builder)
        {
            builder.ToTable("tblTipoVeiculo");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
              .HasColumnType("nvarchar(150)")
              .IsRequired();

           
            builder
              .HasMany(x => x.Veiculos)
              .WithOne(z => z.tipoveiculo);
        }
    }
}
