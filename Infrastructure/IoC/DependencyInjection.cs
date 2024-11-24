using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data.Relational;

namespace MyApp.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, EFClientRepository>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}