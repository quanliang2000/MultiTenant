using Data.Abstracts;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.UoWs
{
    public class TenantUnitOfWork : ITenantUnitOfWork
    {
        private readonly TenantDbContext _tenantDbContext;
        
        public TenantUnitOfWork(TenantDbContext tenantDbContext)
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
