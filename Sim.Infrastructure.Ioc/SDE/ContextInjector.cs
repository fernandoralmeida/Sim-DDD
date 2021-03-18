﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sim.Infrastructure.Ioc.SDE
{
    using Data.Context;
    public class ContextInjector 
    {
        public ContextInjector(IServiceCollection services, IConfiguration config, string connection) 
        {
            services.AddDbContext<DBContextSDE>(options => options.UseSqlServer(config
                .GetConnectionString(connection)));
        }
    }
}
