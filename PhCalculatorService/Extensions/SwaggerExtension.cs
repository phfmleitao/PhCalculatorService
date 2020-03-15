using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace PhCalculatorService.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "PhCalculatorService API",
                        Description = "API to do basic calculations, in order to be an easy-to-understand project for software development training in general.",
                        Contact = new OpenApiContact
                        {
                            Name = "Pedro Henrique Fernandes Marques Leitão",
                            Email = "phfm.leitao@gmail.com",
                            Url = new Uri("https://github.com/phfmleitao")
                        }
                    }
                );

                //Adição do XMLDocumentation do projeto ao Swagger
                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhCalculatorService API V1");
            });
        }
    }
}
