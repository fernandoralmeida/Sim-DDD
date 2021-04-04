using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sim.Infrastructure.IoC.Identity
{

    using Sim.Infrastructure.Data.Context;
    using Sim.Infrastructure.Identity.Entity;
    using Sim.Infrastructure.Identity.Interface;
    using Sim.Infrastructure.Data.Repositories.Identity;

    public class Container
    {
        public void RegisterServices(IServiceCollection services, IConfiguration config, string connection)
        {
            //registra dbcontext identity
            services.AddDbContext<IdentityContext>(options => {

                options.UseSqlServer(config.GetConnectionString(connection));

            });

            //registra o dbcontext padrão do identity
            services.AddDefaultIdentity<Usuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();       
                                    
            //registra automapper identity
            RegisterUsuario(services);

            //configura o identity
            services.Configure<IdentityOptions>(options => {

                //define regras de login
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                //define users
                options.User.RequireUniqueEmail = true;

                //define regras senhas
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                //define Lockout
                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

            });
        }

        private void RegisterUsuario(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
