using Data.Entities;
using Data.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts
{
    public interface ISystemUnitOfWork : IRepository<Tenant>
    {
        Tenant GetTenant(string domain);
        void Save();
        Task SaveAsync();
    }
}
