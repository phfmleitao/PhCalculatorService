using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.IO;
using System;

namespace PhCalculatorService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false);

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhCalculatorService API V1");
            });

            app.UseMvc();
        }
    }
}
