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


            //Igor - 06072021 - Adicionado as instancias de serviços da aplicação o instanciamento do framework de documentação da api, chamado Swagger.
            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Igor - 06072021 - Adicionado a instancia do "app" para utilizar o swagger, nesta classe Configure que é uma das chamadas na inicialização da aplicação.
            //Verificar os middlewares pra ver a prioridade destas chamadas.
            app.UseSwaggerConfiguration();
            
            //O mesmo comentário acima, porém, para utilizar as configurações do pipeline de API.
            app.UseApiConfiguration(env);
        }
    }
}
