using Microsoft.Extensions.DependencyInjection;

namespace Sim.Infrastructure.Ioc.SDE
{
    using Data.Context;
    using Application.SDE.Interface;
    using Application.SDE;
    using Domain.SDE.Entities;
    using Domain.SDE.Services;
    using Domain.SDE.Interfaces.Services;
    using Domain.SDE.Interfaces.Repositories;
    using Data.Repositories.SDE;

    public class Injectors
    {

        public void StartInjectors(IServiceCollection services)
        {
            services.AddScoped<IAppServiceBase<Pessoa>, AppServiceBase<Pessoa>>();
            services.AddScoped<IPessoaAppService, PessoaAppService>();

            services.AddScoped<IServiceBase<Pessoa>, ServiceBase<Pessoa>>();
            services.AddScoped<IPessoaService, PessoaService>();

            services.AddScoped<IRepositoryBase<Pessoa>, RepositoryBase<Pessoa>>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
        }
    }
}
