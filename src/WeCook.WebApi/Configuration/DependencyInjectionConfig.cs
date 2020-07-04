using Microsoft.Extensions.DependencyInjection;
using WeCook.Data;
using WeCook.Data.Repository;
using WeCook.Domain.Interfaces;
using WeCook.Domain.Notifications;
using WeCook.Domain.Services;

namespace WeCook.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services) 
        {
            services.AddScoped<WeCookContext>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IReceitaService, ReceitaService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
