using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Identidade.API.Configuration;

namespace NSE.Identidade.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);

            services.AddApiConfiguration();


            //Igor - 06072021 - Adicionado as instancias de servi�os da aplica��o o instanciamento do framework de documenta��o da api, chamado Swagger.
            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Igor - 06072021 - Adicionado a instancia do "app" para utilizar o swagger, nesta classe Configure que � uma das chamadas na inicializa��o da aplica��o.
            //Verificar os middlewares pra ver a prioridade destas chamadas.
            app.UseSwaggerConfiguration();
            
            //O mesmo coment�rio acima, por�m, para utilizar as configura��es do pipeline de API.
            app.UseApiConfiguration(env);
        }
    }
}
