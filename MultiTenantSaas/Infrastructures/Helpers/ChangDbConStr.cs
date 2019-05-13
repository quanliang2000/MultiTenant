using Data.Contexts;
using Data.Entities;
using Data.Infrastrutures.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantSaas.Infrastructures.Helpers
{
    public static class ChangDbConStr
    {
        public static TenantDbContext Set(Tenant tenant)
        {
            Dictionary<string, string> connStrs = new Dictionary<string, string>();
            var DbConnectionString = ContextConfigurationExtensions.GetConnectionString(tenant);
            connStrs.Add(tenant.Name,DbConnectionString);
           
            DbContextFactory.SetConnectionString(connStrs);
            return DbContextFactory.Create(tenant.Name);
        }
    }
}
