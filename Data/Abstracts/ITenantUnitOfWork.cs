using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts
{
    public interface ITenantUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
