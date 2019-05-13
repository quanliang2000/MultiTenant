using Data.Abstracts;
using Data.Contexts;
using Data.Entities;
using Data.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.UoWs
{
    public class SystemUnitOfWork : SystemRepository<Tenant>,ISystemUnitOfWork
    {
        private readonly SystemDbContext _systemDbContext;

        public SystemUnitOfWork(SystemDbContext systemDbContext) : base(systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public Tenant GetTenant(string domain)
        {
            return GetSingle(x=>x.SubDomain == domain);
        }

        public void Save()
        {
            _systemDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _systemDbContext.SaveChangesAsync();
        }
    }
}
