using Data.Contexts;
using Data.Entities.TenantUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantSaas.Infrastructures.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {

            services.AddIdentity<TenantUser, IdentityRole>()
                .AddEntityFrameworkStores<SystemDbContext>()
                .AddDefaultTokenProviders();


            return services;
        }


        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration, string migrationsAssembly)
        {

            services.AddSystemDataContext(configuration, migrationsAssembly)
                .AddTenantDbContext(configuration, migrationsAssembly);

            return services;
        }

    }
}
