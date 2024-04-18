﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPress.Application.Contracts.Persistence;
using NetPress.Persistence.Repository;

namespace NetPress.Persistence
{
    public static class ServiceRegistrar
    {
        public static void AddNetPressPersistenceServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<NetPressDbContext>(cfg =>
            {
                cfg.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IPostRepository, PostRepository>();
        }
    }
}