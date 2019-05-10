using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts
{
    public interface ISystemUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
