using Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantSaas.Infrastructures.Helpers.DbHelpers
{
    public static class DbInitailizer
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var systemDbContext = serviceScope.ServiceProvider.GetRequiredService<SystemDbContext>();
                systemDbContext.Database.Migrate();


                //var tenantDbContext = serviceScope.ServiceProvider.GetRequiredService<TenantDbContext>();
                //tenantDbContext.Database.Migrate();

                //Seeding code goes here

                if (!systemDbContext.Tenants.Any())
                {
                    foreach (var tenant in SeedData.GetTestTenants())
                    {
                        systemDbContext.Tenants.Add(tenant);
                    }

                    systemDbContext.SaveChanges();
                }

                //if (!tenantDbContext.Customer.Any())
                //{
                //    foreach (var customer in SeedData.GetTextCustomers())
                //    {
                //        tenantDbContext.Customer.Add(customer);
                //    }

                //    tenantDbContext.SaveChanges();
                //}
            }
        }
    }
}
