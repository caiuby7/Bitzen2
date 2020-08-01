using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Bitzen.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerGen(this IServiceCollection services, IHostEnvironment env)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bitzen API ", Version = "v1" });
               
            });
        }

        public static void AddSwaggerConfig(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
               
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bitzen API V1");
                c.RoutePrefix = string.Empty;
            });
        }

    }
}

