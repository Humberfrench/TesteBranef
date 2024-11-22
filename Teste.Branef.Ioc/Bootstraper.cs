using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Teste.Branef.App;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Domain.Interfaces.Services;
using Teste.Branef.Repository;
using Teste.Branef.Repository.Base;
using Teste.Branef.Repository.Context;
using Teste.Branef.Repository.Interfaces;
using Teste.Branef.Repository.UnitOfWork;
using Teste.Branef.Services;
using Teste.Branef.ViewModel.Interfaces;

namespace Teste.Branef.Ioc
{
    public static class Bootstraper
    {
        public static void Initializer(IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped(provider =>
            {
                var context = provider.GetService<IHttpContextAccessor>();
                return (new ClaimsPrincipal());
            });

            services.AddScoped<IContextManager, ContextManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<TesteBranefContext>(options => options.UseSqlServer(configuration.GetConnectionString("branefContext")));

            //Base Class
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseApp), typeof(BaseApp));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }

    }
}