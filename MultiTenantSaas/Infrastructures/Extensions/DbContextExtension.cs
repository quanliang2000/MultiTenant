using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantSaas.Infrastructures.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddSystemDataContext(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            services.AddDbContext<SystemDbContext>(builder =>
                builder.UseSqlServer(configuration.GetConnectionString("SystemConnection"),
                    options => options.MigrationsAssembly(migrationAssembly)));
            return services;
        }


        public static IServiceCollection AddTenantDbContext(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            services.AddDbContext<TenantDbContext>(builder =>
                builder.UseSqlServer(configuration.GetConnectionString("TenantConnection"),
                    options => options.MigrationsAssembly(migrationAssembly)));
            return services;
        }
    }
}
