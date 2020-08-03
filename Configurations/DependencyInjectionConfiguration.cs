using Bitzen.Data.Repositories;
using Bitzen.Interface.Repositories;
using Bitzen.Interface.Services;
using Bitzen.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            ConfigureRepository(services);
            ConfigureServices(services);
        }

        public static void ConfigureRepository(IServiceCollection services)
        {

            services.AddScoped<IPermissaoRepository, PermissaoRepository>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();

            services.AddScoped<ITipoCombustivelRepository, TipoCombustivelRepository>();

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            services.AddScoped<IAbastecimentoRepository, AbastecimentoRepository>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IPermissaoService, PermissaoService>();

            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<ITipoVeiculoService, TipoVeiculoService>();

            services.AddScoped<ITipoCombustivelService, TipoCombustivelService>();

            services.AddScoped<IVeiculoService, VeiculoService>();

            services.AddScoped<IAbastecimentoService , AbastecimentoService>();
        }
    }
}
