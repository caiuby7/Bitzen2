using Bitzen.Data.Mapping;
using Bitzen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoCombustivel> TipoCombustivel { get; set; }

        public DbSet<TipoVeiculo> TipoVeiculo { get; set; }

        public DbSet<Veiculo> Veiculo { get; set; }

        public DbSet<Abastecimento> Abastecimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AbastecimentoMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new TipoCombustivelMap());
            modelBuilder.ApplyConfiguration(new TipoVeiculoMap());
            base.OnModelCreating(modelBuilder);
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
