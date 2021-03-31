using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sim.Infrastructure.IoC.SDE
{

    using Application.SDE.Interface;
    using Application.SDE;
    using Domain.SDE.Entities;
    using Domain.SDE.Services;
    using Domain.SDE.Interfaces.Services;
    using Domain.SDE.Interfaces.Repositories;
    using Data.Repositories.SDE;
    using Data.Context;

    public class Container
    {

        public void RegisterServices(IServiceCollection services, IConfiguration config, string connection)
        {
            //registra o dbcontext aos serviços
            services.AddDbContext<DbContextSDE>(options => options.UseSqlServer(config
                .GetConnectionString(connection)));

            //registra o aplicação, dominio, repositorio aos serviços.
            services.AddScoped<IAppServiceBase<Pessoa>, AppServiceBase<Pessoa>>();
            services.AddScoped<IPessoaAppService, PessoaAppService>();

            services.AddScoped<IServiceBase<Pessoa>, ServiceBase<Pessoa>>();
            services.AddScoped<IPessoaService, PessoaService>();

            services.AddScoped<IRepositoryBase<Pessoa>, RepositoryBase<Pessoa>>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            RegisterEmpresa(services);

        }

        private void RegisterEmpresa(IServiceCollection services)
        {
            //
            services.AddScoped<IAppServiceBase<Empresa>, AppServiceBase<Empresa>>();
            services.AddScoped<IEmpresaAppService, EmpresaAppService>();

            services.AddScoped<IServiceBase<Empresa>, ServiceBase<Empresa>>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<IRepositoryBase<Empresa>, RepositoryBase<Empresa>>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }

    }
}
