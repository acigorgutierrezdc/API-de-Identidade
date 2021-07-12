//Igor 07072021 - Classe criada na unha, refatorando o StartUp, para melhor refatoração do código.
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Identidade.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            //Igor - 06072021 - Estas propriedades são vistas na documentação do swagger, pra clarear a tela de exibição dos serviços API.
            //Sendo impossível o conhecimento das propriedades sem o estudo da documentação devido a amplitude de possibilidades.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "NerdStore Enterprise Identity API",
                    Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications.",
                    Contact = new OpenApiContact() { Name = "Eduardo Pires", Email = "contato@desenvolvedor.io" },
                    //Igor 06072021 - Estudas melhor os tipos de licença pra uso comercial e estudantil, devido a mudanças constantes nas plataformas e orgãos responsáveis.
                    //Este estudo de e ser feito durante o processo de arquiteturação da aplicação e sua utilização, sendo a modificação durante a produção um processo complicado e desconhecido até então.
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}