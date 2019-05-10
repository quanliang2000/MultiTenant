using Data.Abstracts;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.UoWs
{
    public class SystemUnitOfWork : ISystemUnitOfWork
    {
        private readonly TenantDbContext _tenantDbContext;

        public SystemUnitOfWork(TenantDbContext tenantDbContext)
        {
            _tenantDbContext = tenantDbContext;
        }

        public void Save()
        {
            _tenantDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _tenantDbContext.SaveChangesAsync();
        }
    }
}
