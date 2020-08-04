using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Bitzen.Configurations
{
    public static class SwaggerConfiguration
    {
        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\App_Data\XmlDocument.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
        public static void AddSwaggerGen(this IServiceCollection services, IHostEnvironment env)
        {
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bitzen API ", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bitzen API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Caiuby Barros",
                        Email = "caiuby7@hotmail.com",
                        
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Versão de Teste",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                
                c.IncludeXmlComments(GetXmlCommentsPath());

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

