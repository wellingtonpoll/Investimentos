using AutoMapper;
using Investimentos.Dominio.Interfaces.IServicos;
using Investimentos.Dominio.Options;
using Investimentos.Dominio.Servicos;
using Investimentos.Infra.Cache.Extensions;
using Investimentos.Infra.Cache.Interfaces;
using Investimentos.Infra.Rest;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Investimentos.Servico.Api
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
            services.Configure<ServicosExternosOptions>(Configuration.GetSection(ServicosExternosOptions.ServicosExternos));

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddCacheManager<IMemoryCacheProvider>();

            services.AddSingleton<IRestManager, RestManager>();
            services.AddScoped<IInvestimentoServico, InvestimentoServico>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
