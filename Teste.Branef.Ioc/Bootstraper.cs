using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Domain.Interfaces.Services;
using Teste.Branef.Repository;
using Teste.Branef.Repository.Base;
using Teste.Branef.Services;

namespace Teste.Branef.Ioc
{
    public static class Bootstraper
    {
        public static void Initializer(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped(provider =>
            {
                var context = provider.GetService<IHttpContextAccessor>();
                return (new ClaimsPrincipal());
            });

            //Base Class
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            //services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }

    }
}