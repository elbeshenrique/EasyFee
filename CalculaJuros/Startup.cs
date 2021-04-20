using System;
using System.Net.Http;
using CalculaJuros.Application.Drivers;
using CalculaJuros.Constants;
using CalculaJuros.Domain.Services;
using CalculaJuros.Domain.Usecases;
using CalculaJuros.Services;
using CalculaJuros.Usecases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CalculaJuros
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalculaJuros", Version = "v1" });
            });

            InjectDependencies(services);
        }

        private static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<ICalculateFeeUsecase, CalculateCompositeFeeUsecase>();
            services.AddTransient<HttpClient>();
            services.AddTransient<IHttpHandler, Application.Drivers.HttpClientHandler>();

            services.AddTransient<IFeePercentageService>(serviceProvider =>
            {
                var hostIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostIp);
                var urlEndpoint = String.Format(FeePercentageService.UrlEndpointFormat, hostIp);
                var httpHandler = serviceProvider.GetService<IHttpHandler>();
                return new FeePercentageService(httpHandler, urlEndpoint);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalculaJuros v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
